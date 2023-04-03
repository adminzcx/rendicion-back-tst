using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Specifications
{
    public class CashFormAmountByBranchIdSpecification : BaseSpecification<Domain.Entities.CashFormAggregate.CashFormAmount>
    {
        public CashFormAmountByBranchIdSpecification(long branchId)
            : base(x => x.Branch.Id == branchId && x.IsDeleted == false)
        {

            AddInclude(t => t.Branch);
        }
    }
}
