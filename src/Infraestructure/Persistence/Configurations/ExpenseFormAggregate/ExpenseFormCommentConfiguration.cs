using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.ExpenseFormAggregate;
using Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.ExpenseFormAggregate
{
    public class ExpenseFormCommentConfiguration
        : BaseIdConfiguration<ExpenseFormComment>
    {
        public override void Configure(EntityTypeBuilder<ExpenseFormComment> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Description)
               .HasMaxLength(200);

        }
    }
}
