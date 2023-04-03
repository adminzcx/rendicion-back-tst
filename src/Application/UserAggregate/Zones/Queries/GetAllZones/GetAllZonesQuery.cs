using MediatR;
using Prome.Viaticos.Server.Application.UserAggregate.Zones.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.UserAggregate.Zones.Queries.GetAllZones
{

    public class GetAllZonesQuery : IRequest<ICollection<ZoneDto>>
    {
    }
}
