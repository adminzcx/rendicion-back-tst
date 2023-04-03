using MediatR;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetDashboardCashForm
{
    public class GetDashboardCashFormQuery : IRequest<ICollection<DashboardDto>>
    {
        public string Email { get; set; }
    }
}
