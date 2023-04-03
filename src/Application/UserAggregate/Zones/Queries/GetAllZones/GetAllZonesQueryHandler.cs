using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Zones.Dtos;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.UserAggregate.Zones.Queries.GetAllZones
{
    public class GetAllZonesHandler : QueryHandler<GetAllZonesQuery, ICollection<ZoneDto>>
    {
        public GetAllZonesHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<ZoneDto>> Handle(GetAllZonesQuery request, CancellationToken cancellationToken)
        {

            var list = await _unitOfWork
             .Repository<Zone>()
             .ListAllAsync();


            return Map(list);
        }
    }
}
