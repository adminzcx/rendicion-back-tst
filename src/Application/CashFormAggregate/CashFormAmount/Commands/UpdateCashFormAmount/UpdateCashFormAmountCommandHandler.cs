using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Commands.UpdateCashFormAmount
{
    public class UpdateCashFormAmountCommandHandler : CommandHandler<UpdateCashFormAmountCommand>
    {
        public UpdateCashFormAmountCommandHandler(
            IAsyncUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

        public async override Task<Unit> Handle(UpdateCashFormAmountCommand request, CancellationToken cancellationToken)
        {

            var entity = await _unitOfWork
              .Repository<Domain.Entities.CashFormAggregate.CashFormAmount>()
              .GetByIdAsync(request.Id);
            Guard.Against.Null(entity, nameof(request.Id));

            var branch = await this.GetBranchAsync(request.BranchId);

            entity.Amount = request.Amount;
            entity.Branch = branch;
            entity.StartDate = request.StartDate;

            _unitOfWork.Repository<Domain.Entities.CashFormAggregate.CashFormAmount>().Update(entity);
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
