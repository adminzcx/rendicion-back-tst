using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Queries.GetDocumentByLunchForm
{

    public class GetDocumentByLunchFormQuery : IRequest<DocumentAttachedDto>
    {
        public int Id { get; set; }

        public string Email { get; set; }
    }
}
