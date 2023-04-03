using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;
using Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.ExpenseAggregate
{
    public class ExpenseUserConfiguration
        : BaseIdConfiguration<ExpenseUser>
    {
        public override void Configure(EntityTypeBuilder<ExpenseUser> builder)
        {
            base.Configure(builder);


        }
    }
}
