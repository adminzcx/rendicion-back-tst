using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Dtos;
using Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Queries.GetLunchStop
{
    public class GetLunchStopQueryHandler : QueryHandler<GetLunchStopQuery, LunchStopsDto>
    {
        public GetLunchStopQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        {

        }

        public override async Task<LunchStopsDto> Handle(GetLunchStopQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.AdminAggregate.LunchStops>()
                .SingleOrDefaultAsync(new LunchStopByIdSpecification(request.Id));

            return Map(list);
        }
    }
}
