
using Ardalis.GuardClauses;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Specifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Queries.GetExpenseByExpenseForm
{


    public class GetExpenseByExpenseFormQueryHandler : QueryHandler<GetExpenseByExpenseFormQuery, ICollection<ExpenseListDto>>
    {
        public GetExpenseByExpenseFormQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<ExpenseListDto>> Handle(GetExpenseByExpenseFormQuery request, CancellationToken cancellationToken)
        {
            await this.ExpenseFormValid(request.ExpenseFormId);

            var list = await _unitOfWork
                .Repository<Domain.Entities.ExpenseAggregate.Expense>()
                .ListAsync(new ExpenseByExpenseFormIdSpecification(request.ExpenseFormId));

            return Map(list);
        }

        private async Task ExpenseFormValid(int expenseFormId)
        {
            var result = await _unitOfWork
                .Repository<Domain.Entities.ExpenseAggregate.Expense>()
                .GetByIdAsync(expenseFormId);
            Guard.Against.Null(result, "Rendición de Gastos");
        }
    }
}
