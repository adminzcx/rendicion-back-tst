using MediatR;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Queries.GetDashboardLunchForm
{


    public class GetDashboardLunchFormQuery : IRequest<ICollection<DashboardDto>>
    {
        public string Email { get; set; }
    }
}
