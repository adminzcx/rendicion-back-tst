using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.AdminAggreate
{
    public class UserAbsenteeismConfiguration
        : BaseIdConfiguration<UserAbsenteeism>
    {

        public override void Configure(EntityTypeBuilder<UserAbsenteeism> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(t => t.User)
                .WithMany()
                .IsRequired();

            builder
            .Property(b => b.ImportedDate)
            .HasDefaultValueSql("getdate()");
        }
    }
}
