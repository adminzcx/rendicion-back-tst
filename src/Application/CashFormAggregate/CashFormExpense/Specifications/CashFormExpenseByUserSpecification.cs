using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Specifications
{
    public sealed class CashFormExpenseByUserSpecification : BaseSpecification<Domain.Entities.CashFormAggregate.CashFormExpense>
    {
        public CashFormExpenseByUserSpecification(long userId, long cashFormId)
            : base(x => x.User.Id == userId
                        && (cashFormId == 0 || x.CashForm.Id == cashFormId)
                        && x.IsDeleted != true)
        {
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
