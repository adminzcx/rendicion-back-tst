using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Commands.DeleteCashFormExpense
{

    public class DeleteCashFormExpenseCommandHandler
        : CommandHandler<DeleteECashFormExpenseCommand>
    {


        public DeleteCashFormExpenseCommandHandler(
            IAsyncUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public override async Task<Unit> Handle(DeleteECashFormExpenseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
              .Repository<Domain.Entities.CashFormAggregate.CashFormExpense>()
              .GetByIdAsync(request.Id);
            Guard.Against.Null(entity, nameof(request.Id));


            entity.IsDeleted = true;

            _unitOfWork.Repository<Domain.Entities.CashFormAggregate.CashFormExpense>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
