using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.CashFormAggregate;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.CashFormAggregate
{
    public class CashFormStatusConfiguration
        : BaseNameConfiguration<CashFormStatus>
    {
        public override void Configure(EntityTypeBuilder<CashFormStatus> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Name)
                .HasMaxLength(100);
        }
    }
}
