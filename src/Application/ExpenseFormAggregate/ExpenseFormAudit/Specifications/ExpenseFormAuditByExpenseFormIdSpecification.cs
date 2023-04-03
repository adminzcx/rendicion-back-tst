

using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseFormAudit.Specifications
{
    public sealed class ExpenseFormAuditByExpenseFormIdSpecification : BaseSpecification<Domain.Entities.ExpenseFormAggregate.ExpenseFormAudit>
    {
        public ExpenseFormAuditByExpenseFormIdSpecification(long expenseFormId)
            : base(x => x.ExpenseForm.Id == expenseFormId)
        {
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
