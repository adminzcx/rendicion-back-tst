using MediatR;
using Prome.Viaticos.Server.Application.CashFormAggregate.Organism.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.Organism.Queries.GetAllOrganisms
{
    public class GetAllOrganismsQuery : IRequest<ICollection<OrganismDto>>
    {
    }
}
