using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.ExpenseAggregate
{
    public class SourceConfiguration
        : BaseNameConfiguration<Source>
    {
        public override void Configure(EntityTypeBuilder<Source> builder)
        {
            base.Configure(builder);
        }
    }
}
