using MediatR;
using Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Queries.GetAllExpenseStops
{
    public class GetAllExpenseStopsQuery : IRequest<ICollection<StopsListDto>>
    {
        public int TypeStopId { get; set; }
    }
}
