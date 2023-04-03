using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Dtos;
using Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Specifications;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Queries.GetRestaurants
{
    public class GetRestaurantQueryHandler : QueryHandler<GetRestaurantQuery, RestaurantDto>
    {
        public GetRestaurantQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<RestaurantDto> Handle(GetRestaurantQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.LunchAggregate.Restaurant>()
                .SingleOrDefaultAsync(new RestaurantByIdSpecification(request.Id));

            return Map(list);
        }

    }
}
