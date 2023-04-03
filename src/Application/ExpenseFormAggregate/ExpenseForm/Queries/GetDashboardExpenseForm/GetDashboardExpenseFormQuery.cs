using MediatR;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GetDashboardExpenseForm
{


    public class GetDashboardExpenseFormQuery : IRequest<ICollection<DashboardDto>>
    {
        public string Email { get; set; }
    }
}
