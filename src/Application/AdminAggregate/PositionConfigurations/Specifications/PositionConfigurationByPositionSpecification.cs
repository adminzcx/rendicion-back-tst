using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;

namespace Prome.Viaticos.Server.Application.AdminAggregate.PositionConfigurations.Specifications
{


    public class PositionConfigurationByPositionSpecification : BaseSpecification<PositionConfiguration>
    {
        public PositionConfigurationByPositionSpecification(long positionId)
            : base(x => x.Position.Id == positionId)
        {

        }
    }
}
