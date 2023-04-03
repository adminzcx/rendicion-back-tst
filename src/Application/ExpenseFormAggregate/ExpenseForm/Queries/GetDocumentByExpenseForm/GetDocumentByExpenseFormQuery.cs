using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GetDocumentByExpenseForm
{

    public class GetDocumentByExpenseFormQuery : IRequest<DocumentAttachedDto>
    {
        public int Id { get; set; }
    }
}
