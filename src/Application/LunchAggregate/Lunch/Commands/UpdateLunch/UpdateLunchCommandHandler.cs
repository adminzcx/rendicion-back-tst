using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Specifications;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Guards;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Prome.Viaticos.Server.Domain.Entities.LunchAggregate;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Commands.UpdateLunch
{
    public class UpdateLunchCommandHandler : CommandHandler<UpdateLunchCommand>
    {
        private readonly IDateTime _dateTimeService;

        public UpdateLunchCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper,
            IDateTime dateTimeService)
            : base(unitOfWork, mapper)
        {
            _dateTimeService = dateTimeService;
        }

        public override async Task<Unit> Handle(UpdateLunchCommand request, CancellationToken cancellationToken)
        {

            var entity = await FindById<Domain.Entities.LunchAggregate.Lunch>(request.Id);


            entity.Amount = request.Amount;
            entity.LunchDate = request.LunchDate;
            entity.IsInternalCollaborator = request.IsInternalCollaborator;
            entity.User = await this.GetUserAsync(request.UserId);

            #region LunchStopValidation
            //Expense Daily
            var total = await this.GetTotalLunchesByDay((long)request.UserId, entity.LunchDate, request.Id) + entity.Amount;
            var tope = await this.GetTope(entity.LunchDate, false);
            Guard.Against.LunchFormStopDailyGuardValid(total, tope);

            //Expense Monthly
            total = await this.GetTotalLunchesByMonth((long)request.UserId, entity.LunchDate, request.Id) + entity.Amount;
            tope = await this.GetTope(entity.LunchDate, true);
            Guard.Against.LunchFormStopMonthlyGuardValid(total, tope);
            #endregion

            #region Advices
            this.RemoveAdvicesAsync(entity);
            var absenteeismList = await this.GetUserAbsenteeismsAsync(entity.User.Id, entity.LunchDate);
            entity.GenerateAdvices(absenteeismList);
            #endregion

            _unitOfWork.Repository<Domain.Entities.LunchAggregate.Lunch>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

        private async Task<User> GetUserAsync(long? userId)
        {
            if (!userId.HasValue || userId.Value == 0) return null;
            var result = await FindById<User>((int)userId.Value);
            Guard.Against.Null(result, nameof(userId));
            return result;
        }

        private async Task<decimal?> GetTope(DateTime date, bool isMonthly)
        {
            var lunchStop = await _unitOfWork
                .Repository<LunchStops>()
                .SingleOrDefaultAsync(new LunchStopsByValidationDateSpecification(date, isMonthly));
            return lunchStop?.CapAmount;
        }

        private async Task<decimal?> GetTotalLunchesByDay(long userId, DateTime date, long lunchId)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.LunchAggregate.Lunch>()
                .ListAsync(new LunchByUserDateSpecification(userId, lunchId, date));
            return list.Sum(x => x.Amount);
        }

        private async Task<decimal?> GetTotalLunchesByMonth(long userId, DateTime date, long lunchId)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.LunchAggregate.Lunch>()
                .ListAsync(new LunchMonthlyByUserDateSpecification(userId,lunchId, date));
            return list.Sum(x => x.Amount);
        }

        #region Advices
        private async Task<List<UserAbsenteeism>> GetUserAbsenteeismsAsync(long userId, DateTime date)
        {
            return (List<UserAbsenteeism>)await _unitOfWork
                .Repository<UserAbsenteeism>()
                .ListAsync(new UserAbsenteeismByUserSpecification(userId, date));
        }

        private void RemoveAdvicesAsync(Domain.Entities.LunchAggregate.Lunch entity)
        {

            foreach (var item in entity.Advices)
            {
                _unitOfWork.Repository<LunchAdvice>().Delete(item);
            }
        }
        #endregion
    }
}
