using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Reason.Dtos;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Reason.Specifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Reason.Queries.GetAllReasons
{

    public class GetAllReasonsQueryHandler : QueryHandler<GetAllReasonsQuery, ICollection<ReasontDto>>
    {
        public GetAllReasonsQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<ReasontDto>> Handle(GetAllReasonsQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.ExpenseAggregate.Reason>()
                .ListAsync(new ByReasonIncludesSpecification());

            return Map(list);
        }
    }
}
