

using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Queries.GetConceptsByReason
{
    public class GetConceptsByReasonQuery : IRequest<ICollection<ConceptDto>>
    {
        public int ReasonId { get; set; }
    }
}
