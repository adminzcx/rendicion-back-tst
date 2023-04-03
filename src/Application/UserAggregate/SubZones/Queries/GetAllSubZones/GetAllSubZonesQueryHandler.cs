using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.SubZones.Dtos;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.UserAggregate.SubZones.Queries.GetAllSubZones
{
    public class GetAllSubZonesHandler : QueryHandler<GetAllSubZonesQuery, ICollection<SubZoneDto>>
    {
        public GetAllSubZonesHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<SubZoneDto>> Handle(GetAllSubZonesQuery request, CancellationToken cancellationToken)
        {

            var list = await _unitOfWork
             .Repository<SubZone>()
             .ListAllAsync();


            return Map(list);
        }
    }
}
