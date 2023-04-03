using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.UserAggregate
{
    public class BranchConfiguration
        : BaseNameCodeConfiguration<Branch>
    {
        public override void Configure(EntityTypeBuilder<Branch> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(t => t.SubZone)
                .WithMany()
                .IsRequired();
        }
    }
}
