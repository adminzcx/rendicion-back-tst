using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;
using Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.ExpenseAggregate
{
    public class ExpenseAdviceConfiguration
        : BaseIdConfiguration<ExpenseAdvice>
    {
        public override void Configure(EntityTypeBuilder<ExpenseAdvice> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Description)
               .HasMaxLength(200);

        }
    }
}
