using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.ExpenseFormAggregate;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.ExpenseFormAggregate
{
    public class ExpenseFormStatusConfiguration
        : BaseNameConfiguration<ExpenseFormStatus>
    {
        public override void Configure(EntityTypeBuilder<ExpenseFormStatus> builder)
        {
            base.Configure(builder);
        }
    }
}
