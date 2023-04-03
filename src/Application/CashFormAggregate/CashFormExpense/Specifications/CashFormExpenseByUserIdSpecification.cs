using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Specifications
{
    public class CashFormExpenseByUserIdSpecification : BaseSpecification<Domain.Entities.CashFormAggregate.CashFormExpense>
    {
        public CashFormExpenseByUserIdSpecification(long userId)
            : base(x => x.User.Id == userId && x.IsDeleted != true && x.CashForm == null)
        {
            AddInclude(t => t.CashForm);
            AddInclude(t => t.User);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
