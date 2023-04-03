using MediatR;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.AdminAggregate.PositionConfigurations.Queries.GetPositionConfigurationsByConcept
{

    public class GetPositionConfigurationsByConceptQuery : IRequest<ICollection<SelectedPositionDto>>
    {
        public int ConceptId { get; set; }
    }
}
