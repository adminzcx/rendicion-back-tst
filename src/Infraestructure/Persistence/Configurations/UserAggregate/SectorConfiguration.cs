using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.UserAggregate
{
    public class SectorConfiguration
        : BaseNameCodeConfiguration<Sector>
    {

        public override void Configure(EntityTypeBuilder<Sector> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(t => t.Management)
                .WithMany()
                .IsRequired();
        }
    }
}
