using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.UserAggregate
{
    public class UserConfiguration
        : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(t => t.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Email)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(t => t.EmployeeRecord)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasOne(t => t.BranchFrom)
                .WithMany()
                .IsRequired();

            builder
                .HasOne(t => t.Position)
                .WithMany()
                .IsRequired();
        }
    }
}
