using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Dtos;
using Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Specifications;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Queries.GetLunch
{
    public class GetLunchQueryHandler : QueryHandler<GetLunchQuery, LunchDto>
    {
        public GetLunchQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<LunchDto> Handle(GetLunchQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                 .Repository<Domain.Entities.LunchAggregate.Lunch>()
                 .SingleOrDefaultAsync(new LunchByIdSpecification(request.Id));

            return Map(list);
        }
    }
}
