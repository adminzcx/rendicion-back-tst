using MediatR;
using Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Dtos;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Queries.GetRestaurants
{
    public class GetRestaurantQuery : IRequest<RestaurantDto>
    {
        public int Id { get; set; }
    }
}
