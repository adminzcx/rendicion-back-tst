using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormMoney.Specifications
{
    public sealed class MoneyByUserSpecification : BaseSpecification<Domain.Entities.CashFormAggregate.CashFormMoney>
    {
        public MoneyByUserSpecification(long userId)
            : base(x => x.User.Id == userId && x.IsDeleted != true && x.CashForm == null)
        {
            AddInclude(t => t.CashForm);
            AddInclude(t => t.User);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
