using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Specifications
{
    public sealed class RestaurantByIdSpecification : BaseSpecification<Domain.Entities.LunchAggregate.Restaurant>
    {
        public RestaurantByIdSpecification(long id)
            : base(x => x.Id == id)
        {

            AddInclude(t => t.Branch);
        }
    }
}
