using Prome.Viaticos.Server.Application._Common.Helpers.Query;
using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Specifications
{
    public sealed class ExpenseByExpenseFormIdSpecification : BaseSpecification<Domain.Entities.ExpenseAggregate.Expense>
    {
        public ExpenseByExpenseFormIdSpecification(long expenseFormId)
            : base(x => x.ExpenseForm.Id == expenseFormId && x.IsDeleted != true)
        {
            AddInclude(t => t.Status);
            AddInclude(t => t.Reason);
            AddInclude(t => t.Concept);
            AddInclude(t => t.Source);
            AddInclude(t => t.Segment);
            AddInclude(t => t.User);
            AddInclude(t => t.TechnicalVisit);
            AddIncludes(t => t.Include(o => o.ExpenseUsers).ThenInclude(i => i.User));
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
