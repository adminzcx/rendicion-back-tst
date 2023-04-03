using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.UserAggregate
{
    public class SubZoneConfiguration
        : BaseNameCodeConfiguration<SubZone>
    {
        public override void Configure(EntityTypeBuilder<SubZone> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(t => t.Zone)
                .WithMany()
                .IsRequired();
        }
    }
}
