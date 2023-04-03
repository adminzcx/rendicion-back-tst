using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Dtos;
using Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Queries.GetStops
{

    public class GetStopsQueryHandler : QueryHandler<GetStopsQuery, StopsDto>
    {
        public GetStopsQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<StopsDto> Handle(GetStopsQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.AdminAggregate.ExpenseStops>()
                .SingleOrDefaultAsync(new ExpenseStopByIdWithIncludesSpecification(request.Id));

            return Map(list);
        }
    }
}
