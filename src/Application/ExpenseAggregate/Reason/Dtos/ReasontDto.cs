
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Reason.Dtos
{

    public class ReasontDto : IMapFrom<Domain.Entities.ExpenseAggregate.Reason>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ConceptDto> Concepts { get; set; }

    }
}
