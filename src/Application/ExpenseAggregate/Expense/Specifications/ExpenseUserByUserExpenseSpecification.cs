using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Specifications
{

    public sealed class ExpenseUserByUserExpenseSpecification : BaseSpecification<ExpenseUser>
    {
        public ExpenseUserByUserExpenseSpecification(int expenseId)
            : base(x => x.Expense.Id == expenseId && x.IsDeleted != true)
        {
            AddInclude(t => t.User);
        }
    }
}
