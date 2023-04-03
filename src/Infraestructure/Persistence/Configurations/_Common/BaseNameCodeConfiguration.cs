using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations
{
    public abstract class BaseNameCodeConfiguration<T>
        : IEntityTypeConfiguration<T>
        where T : BaseNameCodeEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Code)
                .HasMaxLength(10)
                .IsRequired();

            builder
                .HasIndex(t => t.Code)
                .IsUnique();
        }
    }
}
