using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;

namespace Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Specifications
{

    public sealed class KmPriceConfigurationActiveSpecification : BaseSpecification<KmPriceConfiguration>
    {
        public KmPriceConfigurationActiveSpecification()
            : base(x => x.IsDeleted == false)
        {
            AddInclude(t => t.User);
            AddInclude(t => t.Zone);
            AddInclude(t => t.SubZone);
            ApplyOrderByDescending(x => x.StartDate);
        }
    }
}
