using MediatR;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.AdminAggregate.PositionConfigurations.Commands.CreatePositionConfiguration
{


    public class CreatePositionConfigurationCommand : IRequest, IMapFrom<PositionConfiguration>
    {
        public int ReasonId { get; set; }

        public int ConceptId { get; set; }

        public List<int> Positions { get; set; }
    }
}
