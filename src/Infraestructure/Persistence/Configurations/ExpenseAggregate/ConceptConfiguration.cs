using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.ExpenseAggregate
{
    public class ConceptConfiguration
        : BaseNameConfiguration<Concept>
    {
        public override void Configure(EntityTypeBuilder<Concept> builder)
        {
            base.Configure(builder);

            builder
               .HasOne(t => t.Reason)
               .WithMany(b => b.Concepts)
               .HasForeignKey("ReasonId")
               .IsRequired();


        }
    }
}
