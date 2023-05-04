using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Specifications;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Domain.Entities.LunchFormAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Commands.CreateLunch
{
    public class CreateLunchCommandHandler : CommandHandler<CreateLunchCommand>
    {
        private readonly IDateTime _dateTimeService;

        public CreateLunchCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper,
            IDateTime dateTimeService)
            : base(unitOfWork, mapper)
        {
            _dateTimeService = dateTimeService;
        }

        public override async Task<Unit> Handle(CreateLunchCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await this.GetCurrentUserAsync(request.Email);
            var entity = _mapper.Map<Domain.Entities.LunchAggregate.Lunch>(request);


            #region LunchStopValidation

            if (request.UserId != null)
            {
                //Expense Daily
                var total = await this.GetTotalLunchesByDay((long)request.UserId, entity.LunchDate) + entity.Amount;
                var tope = await this.GetTope(entity.LunchDate, false);
                Guard.Against.LunchFormStopDailyGuardValid(total, tope);

                //Expense Monthly
                total = await this.GetTotalLunchesByMonth((long)request.UserId, entity.LunchDate) + entity.Amount;
                tope = await this.GetTope(entity.LunchDate, true);
                Guard.Against.LunchFormStopMonthlyGuardValid(total, tope);
            }

            #endregion


            entity.User = await this.GetUserAsync(request.UserId);
            entity.CreatedUser = currentUser;
            entity.IsInternalCollaborator = request.IsInternalCollaborator;
            entity.CreatedDate = _dateTimeService.Now;
            entity.LunchForm = await this.GetLunchFormAsync(request.LunchFormId);
            entity.LunchDate = request.LunchDate;
            //entity.Amount = request.Amount;
            //entity.Collaborator = "";
            //entity.EmployeeRecord = "";
            //entity.Device = request.Device;
            //entity.IsDeleted = false;


            #region Advices
            var absenteeismList = await this.GetUserAbsenteeismsAsync(entity.User.Id, entity.LunchDate);
            entity.GenerateAdvices(absenteeismList);
            #endregion


            await _unitOfWork.Repository<Domain.Entities.LunchAggregate.Lunch>().AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

        private async Task<User> GetCurrentUserAsync(string email)
        {
            var users = await _unitOfWork
                .Repository<User>()
                .ListAsync(new ByEmployeeEmailSpecification(email));

            Guard.Against.Null(users, nameof(email));
            Guard.Against.IsValidUser(users);

            return users.First();
        }

        private async Task<User> GetUserAsync(long? userId)
        {
            if (!userId.HasValue || userId == 0) return null;
            var result = await FindById<User>((int)userId.Value);
            Guard.Against.Null(result, nameof(userId));
            return result;
        }

        private async Task<LunchForm> GetLunchFormAsync(int? lunchFormId)
        {
            if (lunchFormId > 0)
                return await FindById<LunchForm>((int)lunchFormId);
            else
                return null;
        }

        private async Task<decimal?> GetTope(DateTime date, bool isMonthly)
        {
            var lunchStop = await _unitOfWork
                .Repository<LunchStops>()
                .SingleOrDefaultAsync(new LunchStopsByValidationDateSpecification(date, isMonthly));
            return lunchStop?.CapAmount;
        }

        private async Task<decimal?> GetTotalLunchesByDay(long userId, DateTime date)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.LunchAggregate.Lunch>()
                .ListAsync(new LunchByUserDateSpecification(userId, 0, date));
            return list.Sum(x => x.Amount);
        }

        private async Task<decimal?> GetTotalLunchesByMonth(long userId, DateTime date)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.LunchAggregate.Lunch>()
                .ListAsync(new LunchMonthlyByUserDateSpecification(userId, 0, date));
            return list.Sum(x => x.Amount);
        }

        #region Advices
        private async Task<IEnumerable<UserAbsenteeism>> GetUserAbsenteeismsAsync(long userId, DateTime date)
        {
            return (IEnumerable<UserAbsenteeism>)await _unitOfWork
                .Repository<UserAbsenteeism>()
                .ListAsync(new UserAbsenteeismByUserSpecification(userId, date));
        }
        #endregion
    }
}
