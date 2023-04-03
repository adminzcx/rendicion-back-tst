
using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Queries.GetAllConcepts
{
    public class GetAllConceptsQuery : IRequest<ICollection<ConceptDto>>
    {
    }
}
