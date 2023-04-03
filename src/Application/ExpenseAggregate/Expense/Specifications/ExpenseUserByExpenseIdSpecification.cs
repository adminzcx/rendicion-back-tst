using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Specifications
{

    public sealed class ExpenseUserByExpenseIdSpecification : BaseSpecification<ExpenseUser>
    {
        public ExpenseUserByExpenseIdSpecification(int userId, int expenseId)
            : base(x => x.User.Id == userId && x.Expense.Id == expenseId && x.IsDeleted != true)
        {

        }
    }
}
