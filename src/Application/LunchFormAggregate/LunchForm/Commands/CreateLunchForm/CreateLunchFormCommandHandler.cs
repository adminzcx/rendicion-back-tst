using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Specifications;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.LunchAggregate;
using Prome.Viaticos.Server.Domain.Entities.LunchFormAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using Prome.Viaticos.Server.Domain.Enums;
using Prome.Viaticos.Server.Domain.ValueObjects.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Commands.CreateLunchForm
{
    public class CreateLunchFormCommandHandler : CommandHandler<CreateLunchFormCommand>
    {
        private readonly IDateTime _dateTimeService;

        public CreateLunchFormCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IDateTime dateTimeService,
           IMapper mapper)
            : base(unitOfWork, mapper)
        {
            _dateTimeService = dateTimeService;
        }

        public override async Task<Unit> Handle(CreateLunchFormCommand request, CancellationToken cancellationToken)
        {
            #region Entity
            var currentUser = await this.GetCurrentUserAsync(request.Email);
            var restaurant = await this.GetRestaurantAsync(request.RestaurantId);
            var status = await FindById<LunchFormStatus>((int)LunchFormStatusEnum.Borrador);
            var entity = _mapper.Map<Domain.Entities.LunchFormAggregate.LunchForm>(request);

            entity.User = currentUser;
            entity.Branch = currentUser.Branch;
            entity.Date = _dateTimeService.Now;
            entity.Status = status;
            entity.Restaurant = restaurant;
            entity.LunchFormNumber = await this.CalculateExpenseFormNumberAsync(currentUser);

            #endregion

            entity.AddAudit(currentUser, _dateTimeService.Now);

            if (!string.IsNullOrEmpty(request.Description))
            {
                entity.AddComment(this.FillCommentToRender(currentUser, request.Description));
            }

            await _unitOfWork.Repository<Domain.Entities.LunchFormAggregate.LunchForm>().AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
        private async Task<string> CalculateExpenseFormNumberAsync(User currentUser)
        {
            return currentUser.EmployeeRecord + " - " + await this.GetNextNumberAsync(currentUser.Id);
        }

        private async Task<int> GetNextNumberAsync(long userId)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.LunchFormAggregate.LunchForm>()
                .CountAsync(new LunchFormByUserSpecification(userId));
            Guard.Against.Null(list, nameof(Email));
            return list + 1;
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

        private async Task<Restaurant> GetRestaurantAsync(int restaurantId)
        {
            var result = await FindById<Restaurant>(restaurantId);
            Guard.Against.Null(result, nameof(restaurantId));
            return result;
        }

        #region Comments


        private Domain.Entities.LunchFormAggregate.LunchFormComment FillCommentToRender(User user, string description)
        {
            var comment = new Domain.Entities.LunchFormAggregate.LunchFormComment(user, description, _dateTimeService.Now);
            return comment;
        }

        #endregion
    }
}
