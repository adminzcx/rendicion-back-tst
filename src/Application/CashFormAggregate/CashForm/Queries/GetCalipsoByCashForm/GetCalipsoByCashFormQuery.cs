using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetCalipsoByCashForm
{

    public class GetCalipsoByCashFormQuery : IRequest<DocumentAttachedDto>
    {
        public int Id { get; set; }
        public string Email { get; set; }


    }
}
