using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.LunchAggregate;
using Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.LunchAggregate
{
    public class LunchConfiguration : BaseIdConfiguration<Lunch>
    {
        public override void Configure(EntityTypeBuilder<Lunch> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Collaborator)
              .HasMaxLength(200);

            builder.Property(t => t.EmployeeRecord)
                .HasMaxLength(100);

            builder.Property(t => t.Amount)
                .IsRequired();

            builder.Property(t => t.Device)
                .HasMaxLength(50);

            builder
             .HasOne(t => t.User)
             .WithMany();

            builder
             .HasOne(t => t.CreatedUser)
             .WithMany();
        }
    }
}
