using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler : CommandHandler<UpdateRestaurantCommand>
    {
        public UpdateRestaurantCommandHandler(
            IAsyncUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }
        public async override Task<Unit> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {

            var entity = await _unitOfWork
              .Repository<Domain.Entities.LunchAggregate.Restaurant>()
              .GetByIdAsync(request.Id);
            Guard.Against.Null(entity, nameof(request.Id));

            var branch = await this.GetBranchAsync(request.BranchId);

            entity.Name = request.Name;
            entity.Branch = branch;
            entity.StartDate = request.StartDate;
            entity.Cuit = request.Cuit;

            _unitOfWork.Repository<Domain.Entities.LunchAggregate.Restaurant>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
        private async Task<Branch> GetBranchAsync(int branchId)
        {
            var result = await FindById<Branch>(branchId);
            Guard.Against.Null(result, nameof(branchId));
            return result;
        }

    }
}
