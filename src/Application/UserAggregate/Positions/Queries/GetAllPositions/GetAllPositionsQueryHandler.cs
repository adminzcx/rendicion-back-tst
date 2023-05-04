using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Positions.Dtos;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.UserAggregate.Positions.Queries.GetAllPositions
{
    public class GetAllPositionsQueryHandler : QueryHandler<GetAllPositionsQuery, ICollection<PositionDto>>
    {
        public GetAllPositionsQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<PositionDto>> Handle(GetAllPositionsQuery request, CancellationToken cancellationToken)
        {

            var list = await _unitOfWork
             .Repository<Position>()
             .ListAllAsync();


            return Map(list);
        }
    }
}
