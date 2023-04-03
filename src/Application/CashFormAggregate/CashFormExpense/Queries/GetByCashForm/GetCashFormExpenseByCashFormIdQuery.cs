using MediatR;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Queries.GetByCashForm
{
    public class GetCashFormExpenseByCashFormIdQuery : IRequest<ICollection<CashFormExpenseDto>>
    {
        public int CashFormId { get; set; }
        public string Email { get; set; }
    }
}
