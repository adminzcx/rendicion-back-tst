using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Specifications
{
    public sealed class ExpenseByCashFormSpecification : BaseSpecification<Domain.Entities.CashFormAggregate.CashFormExpense>
    {
        public ExpenseByCashFormSpecification(long cashFormId, long userId)
            : base(x => ((cashFormId != 0 && x.CashForm.Id == cashFormId) || (cashFormId == 0 && x.CashForm == null))
                        && x.User.Id == userId
                        && x.IsDeleted != true)
        {
            AddInclude(t => t.CashConcept);
            ApplyOrderBy(x => x.Number);
        }
    }
}
