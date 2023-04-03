using MediatR;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Commands.DeleteExpense
{

    public class DeleteExpenseCommand : IRequest
    {
        public int Id { get; set; }
    }
}
