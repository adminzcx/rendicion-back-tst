

using Prome.Viaticos.Server.Application._Common.Mappings;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Dtos
{
    public class ConceptDto : IMapFrom<Domain.Entities.ExpenseAggregate.Concept>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Form { get; set; }

    }
}
