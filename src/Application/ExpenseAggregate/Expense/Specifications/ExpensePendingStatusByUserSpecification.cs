
using Prome.Viaticos.Server.Application._Common.Helpers.Query;
using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Enums;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Specifications
{

    public sealed class ExpensePendingStatusByUserSpecification : BaseSpecification<Domain.Entities.ExpenseAggregate.Expense>
    {
        public ExpensePendingStatusByUserSpecification(long userId)
            : base(x => x.Status.Id == (int)ExpenseStatusEnum.Pendiente && x.User.Id == userId && x.IsDeleted != true && x.ExpenseForm == null)
        {
            AddInclude(t => t.Status);
            AddInclude(t => t.ExpenseForm);
            AddInclude(t => t.Reason);
            AddInclude(t => t.Concept);
            AddInclude(t => t.Source);
            AddInclude(t => t.User);
            AddInclude(t => t.TechnicalVisit);
            AddIncludes(t => t.Include(o => o.ExpenseUsers).ThenInclude(i => i.User));
            AddIncludes(t => t.Include(o => o.Advices));
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
