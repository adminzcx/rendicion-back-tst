using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.CashFormAggregate;
using Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.CashFormAggregate
{
    public class CashFormConfiguration : BaseIdConfiguration<CashForm>
    {
        public override void Configure(EntityTypeBuilder<CashForm> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Period)
                .IsRequired();


            builder
                .HasOne(t => t.Branch)
                .WithMany()
                .IsRequired();

            builder
                .HasOne(t => t.Organism)
                .WithMany()
                .IsRequired();


            builder
                .HasOne(t => t.User)
                .WithMany()
                .IsRequired();

            builder.Property(t => t.CashFormNumber)
                .HasMaxLength(100);

            builder
                .HasMany(p => p.Cashes)
                .WithOne(p => p.CashForm)
                .HasForeignKey("CashFormId")
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);


            builder
                .HasMany(p => p.Expenses)
                .WithOne(p => p.CashForm)
                .HasForeignKey("CashFormId")
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
