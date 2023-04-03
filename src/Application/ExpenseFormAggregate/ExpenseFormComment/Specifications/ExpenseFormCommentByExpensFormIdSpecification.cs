using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseFormComment.Specifications
{

    public sealed class ExpenseFormCommentByExpenseFormIdSpecification : BaseSpecification<Domain.Entities.ExpenseFormAggregate.ExpenseFormComment>
    {
        public ExpenseFormCommentByExpenseFormIdSpecification(long expenseFormId)
            : base(x => x.ExpenseForm.Id == expenseFormId)
        {
            AddInclude(x => x.CommentUser);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
