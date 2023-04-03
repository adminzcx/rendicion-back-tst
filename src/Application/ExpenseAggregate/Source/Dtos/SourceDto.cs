using Prome.Viaticos.Server.Application._Common.Mappings;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Source.Dtos
{
    public class SourceDto : IMapFrom<Domain.Entities.ExpenseAggregate.Source>
    {
        public long Id { get; set; }

        public string Name { get; set; }

    }
}
