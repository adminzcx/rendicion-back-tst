using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchFormComment.Dtos;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchFormComment.Specifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchFormComment.Queries.GetAllLunchFormCommentByFormId
{
    public class GetAllLunchFormCommentByFormIdQueryHandler : QueryHandler<GetAllLunchFormCommentByFormIdQuery, ICollection<LunchFormCommentListDto>>
    {
        public GetAllLunchFormCommentByFormIdQueryHandler(
             IAsyncUnitOfWork unitOfWork,
             IMapper mapper)
             : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<LunchFormCommentListDto>> Handle(GetAllLunchFormCommentByFormIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
                 .Repository<Domain.Entities.LunchFormAggregate.LunchFormComment>()
                 .ListAsync(new LunchFormCommentByExpenseFormIdSpecification(request.Id));

            return Map(entity);
        }

    }
}
