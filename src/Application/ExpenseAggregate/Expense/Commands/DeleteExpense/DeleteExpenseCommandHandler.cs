using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Commands.DeleteExpense
{

    public class DeleteExpenseCommandHandler
        : CommandHandler<DeleteExpenseCommand>
    {


        public DeleteExpenseCommandHandler(
            IAsyncUnitOfWork unitOfWork
           )
            : base(unitOfWork)
        {

        }

        public async override Task<Unit> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
              .Repository<Domain.Entities.ExpenseAggregate.Expense>()
              .GetByIdAsync(request.Id);
            Guard.Against.Null(entity, nameof(request.Id));


            entity.IsDeleted = true;

            _unitOfWork.Repository<Domain.Entities.ExpenseAggregate.Expense>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
