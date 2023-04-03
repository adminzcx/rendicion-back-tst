using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Dtos;
using Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Queries.GetAllLunchStops
{
    public class GetAllLunchStopsQueryHandler : QueryHandler<GetAllLunchStopsQuery, ICollection<LunchStopsListDto>>
    {
        public GetAllLunchStopsQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper
           )
            : base(unitOfWork, mapper)
        {

        }

        public override async Task<ICollection<LunchStopsListDto>> Handle(GetAllLunchStopsQuery request, CancellationToken cancellationToken)
        {

            var list = await _unitOfWork
             .Repository<Domain.Entities.AdminAggregate.LunchStops>()
             .ListAsync(new LunchStopsByStartDateSpecification());

            return Map(list);
        }
    }
}
