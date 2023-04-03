using Prome.Viaticos.Server.Application._Common.Helpers.Query;
using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Specifications
{

    public sealed class ExpenseByIdWithIncludesSpecification : BaseSpecification<Domain.Entities.ExpenseAggregate.Expense>
    {
        public ExpenseByIdWithIncludesSpecification(long id)
            : base(x => x.Id == id)
        {
            AddInclude(t => t.Status);
            AddInclude(t => t.Reason);
            AddInclude(t => t.Concept);
            AddInclude(t => t.Segment);
            AddInclude(t => t.Source);
            AddInclude(t => t.User);
            AddInclude(t => t.TechnicalVisit);
            AddIncludes(t => t.Include(o => o.ExpenseUsers).ThenInclude(i => i.User));
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
