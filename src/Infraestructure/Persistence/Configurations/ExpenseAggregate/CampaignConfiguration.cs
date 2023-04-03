using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.ExpenseAggregate
{
    public class CampaignConfiguration
        : BaseNameConfiguration<Campaign>
    {
        public override void Configure(EntityTypeBuilder<Campaign> builder)
        {
            base.Configure(builder);

        }
    }
}
