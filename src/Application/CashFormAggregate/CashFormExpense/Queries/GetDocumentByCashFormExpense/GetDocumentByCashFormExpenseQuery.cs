using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Queries.GetDocumentByCashFormExpense
{

    public class GetDocumentByCashFormExpenseQuery : IRequest<DocumentAttachedDto>
    {
        public int Id { get; set; }
    }
}
