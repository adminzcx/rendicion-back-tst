using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Dtos;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAudit.Queries.GetAllCashFormAuditByCashFormId
{
    public class GetAllCashFormAuditByCashFormIdQueryHandler : QueryHandler<GetAllCashFormAuditByCashFormIdQuery, ICollection<CashFormListDto>>
    {
        public GetAllCashFormAuditByCashFormIdQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<CashFormListDto>> Handle(GetAllCashFormAuditByCashFormIdQuery request, CancellationToken cancellationToken)
        {
            // var currentUser = await this.GetCurrentUserAsync(request.ExpenseFormId);

            var list = await _unitOfWork
                .Repository<Domain.Entities.CashFormAggregate.CashForm>()
                .ListAsync(new CashFormReportByStatusSpecification(1, request.CashFormId));

            return Map(list);
        }


    }
}