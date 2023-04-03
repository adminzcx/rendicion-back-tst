using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Specifications
{
    public class LunchStopsByStartDateSpecification : BaseSpecification<Domain.Entities.AdminAggregate.LunchStops>
    {
        public LunchStopsByStartDateSpecification() : base(x => x.IsDeleted != true)
        {
            ApplyOrderByDescending(x => x.ValidityStartDate);
        }
    }
}
