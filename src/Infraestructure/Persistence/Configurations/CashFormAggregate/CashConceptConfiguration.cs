using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.CashFormAggregate;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.CashFormAggregate
{
    public class CashConceptConfiguration
        : BaseNameConfiguration<CashConcept>
    {
        public override void Configure(EntityTypeBuilder<CashConcept> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Name)
                .HasMaxLength(100);

            builder
                .HasOne(t => t.CostCenter)
                .WithMany();
        }
    }
}
