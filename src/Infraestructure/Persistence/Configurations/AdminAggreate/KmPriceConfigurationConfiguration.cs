using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.AdminAggreate
{
    public class KmPriceConfigurationConfiguration
        : BaseIdConfiguration<KmPriceConfiguration>
    {

        public override void Configure(EntityTypeBuilder<KmPriceConfiguration> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(t => t.SubZone)
                .WithMany();

            builder
                .HasOne(t => t.Zone)
                .WithMany();



            builder
                .HasOne(t => t.User)
                .WithMany();

        }
    }
}
