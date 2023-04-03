using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Campaign.Specifications
{
    public class CampaignsEnabledSpecification : BaseSpecification<Domain.Entities.ExpenseAggregate.Campaign>
    {
        public CampaignsEnabledSpecification()
            : base(x => x.IsDeleted == false)
        {
        }
    }
}
