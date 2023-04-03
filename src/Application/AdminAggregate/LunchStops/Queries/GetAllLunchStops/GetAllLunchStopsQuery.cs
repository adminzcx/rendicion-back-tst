using MediatR;
using Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Queries.GetAllLunchStops
{
    public class GetAllLunchStopsQuery : IRequest<ICollection<LunchStopsListDto>>
    {
        public int TypeStopId { get; set; }
    }
}
