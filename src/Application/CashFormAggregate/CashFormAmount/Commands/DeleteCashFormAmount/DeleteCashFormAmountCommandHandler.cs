using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Commands.DeleteCashFormAmount
{
    public class DeleteCashFormAmountCommandHandler
        : CommandHandler<DeleteCashFormAmountCommand>
    {
        public DeleteCashFormAmountCommandHandler(
            IAsyncUnitOfWork unitOfWork
           )
            : base(unitOfWork)
        {
        }

        public async override Task<Unit> Handle(DeleteCashFormAmountCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
              .Repository<Domain.Entities.CashFormAggregate.CashFormAmount>()
              .GetByIdAsync(request.Id);
            Guard.Against.Null(entity, nameof(request.Id));


            entity.IsDeleted = true;

            _unitOfWork.Repository<Domain.Entities.CashFormAggregate.CashFormAmount>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
