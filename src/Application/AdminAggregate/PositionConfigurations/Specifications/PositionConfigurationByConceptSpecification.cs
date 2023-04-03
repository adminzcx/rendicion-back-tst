using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;

namespace Prome.Viaticos.Server.Application.AdminAggregate.PositionConfigurations.Specifications
{


    public class PositionConfigurationByConceptSpecification : BaseSpecification<PositionConfiguration>
    {
        public PositionConfigurationByConceptSpecification(long conceptId)
            : base(x => x.Concept.Id == conceptId)
        {

        }
    }
}
