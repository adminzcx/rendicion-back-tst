using MediatR;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashConcept.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashConcept.Queries.GetAllCashConcepts
{
    public class GetAllCashConceptsQuery : IRequest<ICollection<CashConceptDto>>
    {
    }
}
