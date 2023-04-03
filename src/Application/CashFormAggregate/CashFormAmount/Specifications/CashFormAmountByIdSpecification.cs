using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Specifications
{
    public class CashFormAmountByIdSpecification : BaseSpecification<Domain.Entities.CashFormAggregate.CashFormAmount>
    {
        public CashFormAmountByIdSpecification(long id)
            : base(x => x.Id == id)
        {

            AddInclude(t => t.Branch);
        }
    }
}
