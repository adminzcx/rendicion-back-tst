using MediatR;
using Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Dtos;

namespace Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Queries.GetStops
{

    public class GetStopsQuery : IRequest<StopsDto>
    {
        public int Id { get; set; }
    }
}
