using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.LunchAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Commands.PatchLunchForm
{
    public class PatchLunchFormCommandHandler : CommandHandler<PatchLunchFormCommand>
    {
        private readonly IDateTime _dateTimeService;

        public PatchLunchFormCommandHandler(
                IAsyncUnitOfWork unitOfWork,
                IDateTime dateTimeService) : base(unitOfWork)
        {
            _dateTimeService = dateTimeService;
        }

        public override async Task<Unit> Handle(PatchLunchFormCommand request, CancellationToken cancellationToken)
        {
            #region Entity
            var currentUser = await GetCurrentUserAsync(request.Email);
            var entity = await FindById<Domain.Entities.LunchFormAggregate.LunchForm>(request.Id);
            Guard.Against.Null(entity, nameof(request.Id));
            entity.User = currentUser;
            entity.Date = _dateTimeService.Now;
            entity.BussinesDays = request.BussinesDays;
            entity.Cai = request.Cai;
            entity.InvoiceNumber = request.InvoiceNumber;
            entity.InvoiceType = request.InvoiceType;
            entity.Iva = request.Iva;
            entity.ExceptionResponse = request.ExceptionResponse;
            entity.NumberOfTickets = request.NumberOfTickets;
            entity.Restaurant = await this.GetRestaurantAsync(request.RestaurantId);
            entity.SubTotal = request.Subtotal;
            entity.Total = request.Total;
            #endregion

            _unitOfWork.Repository<Domain.Entities.LunchFormAggregate.LunchForm>().Update(entity);
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

        private async Task<Restaurant> GetRestaurantAsync(int restaurantId)
        {
            var result = await FindById<Restaurant>(restaurantId);
            Guard.Against.Null(result, nameof(restaurantId));
            return result;
        }
    }
}
