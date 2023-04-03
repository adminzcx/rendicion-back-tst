using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.AdminAggreate
{
    public class PositionConfigurationConfiguration
        : BaseIdConfiguration<PositionConfiguration>
    {

        public override void Configure(EntityTypeBuilder<PositionConfiguration> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(t => t.Position)
                .WithMany()
                .IsRequired();


            builder
                .HasOne(t => t.Reason)
                .WithMany()
                .IsRequired();


            builder
                .HasOne(t => t.Concept)
                .WithMany()
                .IsRequired();
        }
    }
}
