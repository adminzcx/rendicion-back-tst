using Prome.Viaticos.Server.Application._Common.Mappings;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.RejectReason.Dtos
{
    public class RejectReasonDto : IMapFrom<Domain.Entities.ExpenseAggregate.RejectReason>
    {
        public long Id { get; set; }

        public string Name { get; set; }

    }
}
