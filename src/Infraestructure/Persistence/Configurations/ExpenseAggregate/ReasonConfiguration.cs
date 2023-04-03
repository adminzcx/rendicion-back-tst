using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.ExpenseAggregate
{
    public class ReasonConfiguration
        : BaseNameConfiguration<Reason>
    {
        public override void Configure(EntityTypeBuilder<Reason> builder)
        {
            base.Configure(builder);


        }
    }
}
