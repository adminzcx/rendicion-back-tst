using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Specifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseFormAudit.Queries.GetAllExpenseFormAuditByExpenseFormId
{

    public class GetAllExpenseFormAuditByExpenseFormIdQueryHandler : QueryHandler<GetAllExpenseFormAuditByExpenseFormIdQuery, ICollection<ExpenseFormListDto>>
    {
        public GetAllExpenseFormAuditByExpenseFormIdQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<ExpenseFormListDto>> Handle(GetAllExpenseFormAuditByExpenseFormIdQuery request, CancellationToken cancellationToken)
        {
            // var currentUser = await this.GetCurrentUserAsync(request.ExpenseFormId);

            var list = await _unitOfWork
                .Repository<Domain.Entities.ExpenseFormAggregate.ExpenseForm>()
                .ListAsync(new ExpenseFormByStatusSpecification(1, request.ExpenseFormId));

            return Map(list);
        }


    }
}
