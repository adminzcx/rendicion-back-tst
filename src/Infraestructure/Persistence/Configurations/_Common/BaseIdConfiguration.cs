using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common
{
    public abstract class BaseIdConfiguration<T>
        : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {

        }
    }
}
