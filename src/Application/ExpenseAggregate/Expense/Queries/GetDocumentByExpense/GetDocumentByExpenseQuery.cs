using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Queries.GetDocumentByExpense
{

    public class GetDocumentByExpenseQuery : IRequest<DocumentAttachedDto>
    {
        public int Id { get; set; }
    }
}
