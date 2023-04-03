using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.CashFormAggregate;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.CashFormAggregate
{
    public class MoneyTypeConfiguration
        : BaseNameConfiguration<MoneyType>
    {
        public override void Configure(EntityTypeBuilder<MoneyType> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Name)
                .HasMaxLength(100);


        }
    }
}
