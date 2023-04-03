using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Dtos;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Specifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchFormAudit.Queries.GetAllLunchFormAuditByLunchFormId
{

    public class GetAllLunchFormAuditByLunchFormIdQueryHandler : QueryHandler<GetAllLunchFormAuditByLunchFormIdQuery, ICollection<LunchFormListDto>>
    {
        public GetAllLunchFormAuditByLunchFormIdQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<LunchFormListDto>> Handle(GetAllLunchFormAuditByLunchFormIdQuery request, CancellationToken cancellationToken)
        {
            // var currentUser = await this.GetCurrentUserAsync(request.ExpenseFormId);

            var list = await _unitOfWork
                .Repository<Domain.Entities.LunchFormAggregate.LunchForm>()
                .ListAsync(new LunchFormReportByStatusSpecification(1, request.ExpenseFormId));

            return Map(list);
        }


    }
}
