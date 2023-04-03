
using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler : CommandHandler<CreateRestaurantCommand>
    {


        public CreateRestaurantCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper
           )
            : base(unitOfWork, mapper)
        {

        }
        public override async Task<Unit> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var branch = await this.GetBranchAsync(request.BranchId);

            var entity = _mapper.Map<Domain.Entities.LunchAggregate.Restaurant>(request);
            entity.Branch = branch;

            await _unitOfWork.Repository<Domain.Entities.LunchAggregate.Restaurant>().AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

        private async Task<Domain.Entities.UserAggregate.Branch> GetBranchAsync(int? branchId)
        {
            if (!branchId.HasValue) return null;
            var result = await FindById<Domain.Entities.UserAggregate.Branch>((int)branchId);
            Guard.Against.Null(result, nameof(branchId));
            return result;
        }
    }
}
