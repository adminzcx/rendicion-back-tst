using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.CashFormAggregate;
using Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.CashFormAggregate
{
    public class CashFormExpenseConfiguration : BaseIdConfiguration<CashFormExpense>
    {
        public override void Configure(EntityTypeBuilder<CashFormExpense> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.DocumentAttached)
                .HasMaxLength(400);

            builder.Property(t => t.Total)
                .IsRequired();

            builder.Property(t => t.Date)
                .IsRequired();

            builder
                .HasOne(t => t.CostCenter)
                .WithMany();

            builder
                .HasOne(t => t.CashConcept)
                .WithMany();

            builder
             .HasOne(t => t.User)
             .WithMany();


        }
    }
}
