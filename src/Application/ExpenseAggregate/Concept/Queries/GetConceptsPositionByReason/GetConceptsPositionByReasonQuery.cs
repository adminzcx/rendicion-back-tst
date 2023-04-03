
using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Queries.GetConceptsPositionByReason
{
    public class GetConceptsPositionByReasonQuery : IRequest<ICollection<ConceptDto>>
    {
        public int ReasonId { get; set; }

        public string Email { get; set; }
    }
}
