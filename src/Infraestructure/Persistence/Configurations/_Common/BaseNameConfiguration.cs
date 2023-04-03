using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations
{
    public abstract class BaseNameConfiguration<T>
        : IEntityTypeConfiguration<T>
        where T : BaseNameEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}
