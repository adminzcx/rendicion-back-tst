using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.CashFormAggregate;
using Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.CashFormAggregate
{
    public class CashFormMoneyConfiguration : BaseIdConfiguration<CashFormMoney>
    {
        public override void Configure(EntityTypeBuilder<CashFormMoney> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(t => t.MoneyType)
                .WithMany();

            builder.Property(t => t.Total)
                .IsRequired();

            builder.Property(t => t.Amount)
                .IsRequired();
        }
    }
}
