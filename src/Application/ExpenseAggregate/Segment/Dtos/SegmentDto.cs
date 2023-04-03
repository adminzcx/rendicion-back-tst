using Prome.Viaticos.Server.Application._Common.Mappings;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Segment.Dtos
{
    public class SegmentDto : IMapFrom<Domain.Entities.ExpenseAggregate.Segment>
    {
        public long Id { get; set; }

        public string Name { get; set; }

    }
}
