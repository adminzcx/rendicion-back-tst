using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.LunchFormAggregate;
using Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.LunchFormAggregate
{
    public class LunchFormStatusConfiguration
        : BaseIdConfiguration<LunchFormStatus>
    {
        public override void Configure(EntityTypeBuilder<LunchFormStatus> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Name)
                 .HasMaxLength(100)
                 .IsRequired();
        }
    }
}
