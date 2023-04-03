using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormComment.Dtos;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormComment.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormComment.Queries.GetAllCashFormCommentByFormId
{
    public class GetAllCashFormCommentByFormIdQueryHandler : QueryHandler<GetAllCashFormCommentByFormIdQuery, ICollection<CashFormCommentListDto>>
    {
        public GetAllCashFormCommentByFormIdQueryHandler(
             IAsyncUnitOfWork unitOfWork,
             IMapper mapper)
             : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<CashFormCommentListDto>> Handle(GetAllCashFormCommentByFormIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
                 .Repository<Domain.Entities.CashFormAggregate.CashFormComment>()
                 .ListAsync(new CashFormCommentByCashFormIdSpecification(request.Id));

            return Map(entity);
        }

    }
}
