using MediatR;
using Prome.Viaticos.Server.Application.UserAggregate.SubZones.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.UserAggregate.SubZones.Queries.GetAllSubZones
{

    public class GetAllSubZonesQuery : IRequest<ICollection<SubZoneDto>>
    {
    }
}
