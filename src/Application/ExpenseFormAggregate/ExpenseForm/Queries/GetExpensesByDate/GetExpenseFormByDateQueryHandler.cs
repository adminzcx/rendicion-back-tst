using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.AdminAggregate.ExportSearch.Specification;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Specifications;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GetExpensesByDate
{
    public class GetExpenseFormByDateQueryHandler : QueryHandler<GetExpenseFormByDateQuery, ICollection<ExpenseFormDto>>
    {
        public GetExpenseFormByDateQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper
        )
            : base(unitOfWork, mapper)
        {}

        public override async Task<ICollection<ExpenseFormDto>> Handle(GetExpenseFormByDateQuery request, CancellationToken cancellationToken)
        {

            IReadOnlyCollection<Domain.Entities.ExpenseFormAggregate.ExpenseForm> list;

            if (request.StartDate == request.EndDate)
            {

                list = await _unitOfWork
                   .Repository<Domain.Entities.ExpenseFormAggregate.ExpenseForm>()
                   .ListAsync(new ExpenseFormByExactExportSearchSpecification(request.StartDate));

            }
            else
            {
                list = await _unitOfWork
                   .Repository<Domain.Entities.ExpenseFormAggregate.ExpenseForm>()
                   .ListAsync(new ExpenseFormByExportSearchSpecification(request.StartDate, request.EndDate));
            }

            return Map(list);
        }
    }
}