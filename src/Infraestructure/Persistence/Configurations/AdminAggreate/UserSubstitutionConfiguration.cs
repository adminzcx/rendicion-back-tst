using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.AdminAggreate
{
    public class UserSubstitutionConfiguration
        : BaseIdConfiguration<UserSubstitution>
    {

        public override void Configure(EntityTypeBuilder<UserSubstitution> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(t => t.User)
                .WithMany()
                .IsRequired();


            builder
                .HasOne(t => t.ReplaceByUser)
                .WithMany()
                .IsRequired();


            builder
            .Property(b => b.CreatedDate)
            .HasDefaultValueSql("getdate()");
        }
    }
}
