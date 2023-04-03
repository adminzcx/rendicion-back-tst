using MediatR;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Commands.DeleteLunch
{
    public class DeleteLunchCommand : IRequest
    {
        public int Id { get; set; }
    }
}
