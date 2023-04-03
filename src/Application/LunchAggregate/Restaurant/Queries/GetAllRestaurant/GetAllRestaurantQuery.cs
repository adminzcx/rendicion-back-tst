using MediatR;
using Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Queries.GetAllRestaurant
{
    public class GetAllRestaurantQuery : IRequest<ICollection<RestaurantListDto>>
    {

    }
}
