using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Specifications
{
    public class CashFormAmountSpecification : BaseSpecification<Domain.Entities.CashFormAggregate.CashFormAmount>
    {
        public CashFormAmountSpecification()
            : base(x => x.IsDeleted != true)
        {
            AddInclude(t => t.Branch);
        }

    }
}
