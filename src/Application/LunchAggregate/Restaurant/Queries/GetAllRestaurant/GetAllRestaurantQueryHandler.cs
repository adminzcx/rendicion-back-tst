using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Dtos;
using Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Specifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Queries.GetAllRestaurant
{
    public class GetAllRestaurantQueryHandler : QueryHandler<GetAllRestaurantQuery, ICollection<RestaurantListDto>>
    {
        public GetAllRestaurantQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper
           )
            : base(unitOfWork, mapper)
        {
        }

        public override async Task<ICollection<RestaurantListDto>> Handle(GetAllRestaurantQuery request, CancellationToken cancellationToken)
        {

            var list = await _unitOfWork
             .Repository<Domain.Entities.LunchAggregate.Restaurant>()
             .ListAsync(new RestaurantByStartDateSpecification());

            return Map(list);
        }
    }
}
