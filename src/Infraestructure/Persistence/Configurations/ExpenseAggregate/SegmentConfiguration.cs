using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.ExpenseAggregate
{
    public class SegmentConfiguration
        : BaseNameConfiguration<Segment>
    {
        public override void Configure(EntityTypeBuilder<Segment> builder)
        {
            base.Configure(builder);

        }
    }
}
