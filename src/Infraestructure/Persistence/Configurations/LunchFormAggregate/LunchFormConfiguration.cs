using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.LunchFormAggregate;
using Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.LunchFormAggregate
{
    public class LunchFormConfiguration : BaseIdConfiguration<LunchForm>
    {
        public override void Configure(EntityTypeBuilder<LunchForm> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Date)
                .IsRequired();

            builder.Property(t => t.BussinesDays)
                .IsRequired();

            builder.Property(t => t.Cai)
                .IsRequired();

            builder.Property(t => t.Iva)
                .IsRequired();

            builder.Property(t => t.InvoiceType)
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(t => t.InvoiceNumber)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.NumberOfTickets)
                .IsRequired();

            builder.Property(t => t.SubTotal)
                .IsRequired();

            builder.Property(t => t.Total)
                .IsRequired();

            builder
                .HasOne(t => t.Restaurant)
                .WithMany()
                .IsRequired();

            builder
                .HasOne(t => t.Status)
                .WithMany()
                .IsRequired();

            builder
                .HasOne(t => t.Branch)
                .WithMany()
                .IsRequired();

            builder
                .HasOne(t => t.User)
                .WithMany()
                .IsRequired();

            builder.Property(t => t.LunchFormNumber)
                .HasMaxLength(100);

            builder
                .HasMany(p => p.Lunches)
                .WithOne(p => p.LunchForm)
                .HasForeignKey("LunchFormId")
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
