using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetDocumentByCashForm
{

    public class GetDocumentByCashFormQuery : IRequest<DocumentAttachedDto>
    {
        public int Id { get; set; }
        public string Email { get; set; }


    }
}
