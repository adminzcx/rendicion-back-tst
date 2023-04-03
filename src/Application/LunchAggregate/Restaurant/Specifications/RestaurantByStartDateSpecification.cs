using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Specifications
{
    public sealed class RestaurantByStartDateSpecification : BaseSpecification<Domain.Entities.LunchAggregate.Restaurant>
    {
        public RestaurantByStartDateSpecification()
            : base(x => x.IsDeleted != true)
        {
            AddInclude(t => t.Branch);
            ApplyOrderByDescending(x => x.StartDate);
        }

    }
}
