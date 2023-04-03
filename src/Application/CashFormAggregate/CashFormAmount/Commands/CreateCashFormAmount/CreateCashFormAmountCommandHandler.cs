using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Commands.CreateCashFormAmount
{
    public class CreateCashFormAmountCommandHandler : CommandHandler<CreateCashFormAmountCommand>
    {
        public CreateCashFormAmountCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper
            )
              : base(unitOfWork, mapper)
        {

        }

        public override async Task<Unit> Handle(CreateCashFormAmountCommand request, CancellationToken cancellationToken)
        {
            var branch = await this.GetBranchAsync(request.BranchId);

            var entity = _mapper.Map<Domain.Entities.CashFormAggregate.CashFormAmount>(request);
            entity.Branch = branch;

            await _unitOfWork.Repository<Domain.Entities.CashFormAggregate.CashFormAmount>().AddAsync(entity);
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
