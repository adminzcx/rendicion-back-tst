using MediatR;

namespace Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Commands.DeleteLunchStops
{
    public class DeleteLunchStopsCommand : IRequest
    {
        public int Id { get; set; }
    }
}
