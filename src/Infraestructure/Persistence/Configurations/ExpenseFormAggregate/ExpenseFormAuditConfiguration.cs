using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.ExpenseFormAggregate;
using Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.ExpenseFormAggregate
{
    public class ExpenseFormAuditConfiguration
        : BaseIdConfiguration<ExpenseFormAudit>
    {
        public override void Configure(EntityTypeBuilder<ExpenseFormAudit> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Description)
               .HasMaxLength(200);
        }
    }
}
