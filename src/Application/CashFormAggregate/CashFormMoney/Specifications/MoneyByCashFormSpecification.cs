using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormMoney.Specifications
{
    public sealed class MoneyByCashFormSpecification : BaseSpecification<Domain.Entities.CashFormAggregate.CashFormMoney>
    {
        public MoneyByCashFormSpecification(long cashFormId)
            : base(x => x.CashForm.Id == cashFormId)
        {
            AddInclude(t => t.MoneyType);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
