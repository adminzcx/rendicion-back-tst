using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Specifications;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Queries.GetExpense
{


    public class GetExpenseQueryHandler : QueryHandler<GetExpenseQuery, ExpenseDto>
    {
        public GetExpenseQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ExpenseDto> Handle(GetExpenseQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                 .Repository<Domain.Entities.ExpenseAggregate.Expense>()
                 .SingleOrDefaultAsync(new ExpenseByIdWithIncludesSpecification(request.Id));

            return Map(list);
        }
    }
}
