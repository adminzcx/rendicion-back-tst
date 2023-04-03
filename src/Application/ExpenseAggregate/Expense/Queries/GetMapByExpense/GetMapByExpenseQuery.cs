using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Queries.GetMapByExpense
{


    public class GetMapByExpenseQuery : IRequest<DocumentAttachedDto>
    {
        public int Id { get; set; }
    }
}
