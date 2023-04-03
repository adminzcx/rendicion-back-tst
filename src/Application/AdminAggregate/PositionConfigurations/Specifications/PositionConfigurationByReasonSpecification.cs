using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;


namespace Prome.Viaticos.Server.Application.AdminAggregate.PositionConfigurations.Specifications
{


    public class PositionConfigurationByReasonSpecification : BaseSpecification<PositionConfiguration>
    {
        public PositionConfigurationByReasonSpecification(long reasonId)
            : base(x => x.Reason.Id == reasonId)
        {

        }
    }
}
