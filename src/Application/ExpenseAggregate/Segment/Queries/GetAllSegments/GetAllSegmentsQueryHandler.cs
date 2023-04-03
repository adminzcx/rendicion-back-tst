using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Segment.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Segment.Queries.GetAllSegments
{


    public class GetAllSegmentsQueryHandler : QueryHandler<GetAllSegmentsQuery, ICollection<SegmentDto>>
    {
        public GetAllSegmentsQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<SegmentDto>> Handle(GetAllSegmentsQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.ExpenseAggregate.Segment>()
                .ListAllAsync();

            return Map(list);
        }
    }
}
