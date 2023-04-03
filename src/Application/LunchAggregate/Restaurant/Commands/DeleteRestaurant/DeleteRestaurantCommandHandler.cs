using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler
        : CommandHandler<DeleteRestaurantCommand>
    {
        public DeleteRestaurantCommandHandler(
            IAsyncUnitOfWork unitOfWork
           )
            : base(unitOfWork)
        {

        }

        public async override Task<Unit> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
              .Repository<Domain.Entities.LunchAggregate.Restaurant>()
              .GetByIdAsync(request.Id);
            Guard.Against.Null(entity, nameof(request.Id));


            entity.IsDeleted = true;

            _unitOfWork.Repository<Domain.Entities.LunchAggregate.Restaurant>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

    }
}
