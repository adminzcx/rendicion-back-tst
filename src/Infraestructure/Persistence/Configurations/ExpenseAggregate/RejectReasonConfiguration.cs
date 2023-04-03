using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.ExpenseAggregate
{
    public class RejectReasonConfiguration
        : BaseNameConfiguration<RejectReason>
    {
        public override void Configure(EntityTypeBuilder<RejectReason> builder)
        {
            base.Configure(builder);
        }
    }
}
