using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Queries.GetExpense
{

    public class GetExpenseQuery : IRequest<ExpenseDto>
    {
        public int Id { get; set; }
    }
}
