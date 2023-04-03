using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.RejectReason.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.RejectReason.Queries.GetAllRejectReasons
{
    public class GetAllRejectReasonsQueryHandler : QueryHandler<GetAllRejectReasonsQuery, ICollection<RejectReasonDto>>
    {
        public GetAllRejectReasonsQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<RejectReasonDto>> Handle(GetAllRejectReasonsQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.ExpenseAggregate.RejectReason>()
                .ListAllAsync();

            return Map(list);
        }
    }
}
