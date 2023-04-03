using MediatR;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommand : IRequest
    {
        public int Id { get; set; }
    }
}
