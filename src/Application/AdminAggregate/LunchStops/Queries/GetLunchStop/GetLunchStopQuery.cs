using MediatR;
using Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Dtos;

namespace Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Queries.GetLunchStop
{
    public class GetLunchStopQuery : IRequest<LunchStopsDto>
    {
        public int Id { get; set; }
    }
}
