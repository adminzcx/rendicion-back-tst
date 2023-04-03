using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Specifications
{
    public sealed class ExpenseStopByTypeSpecification : BaseSpecification<Domain.Entities.AdminAggregate.ExpenseStops>
    {
        public ExpenseStopByTypeSpecification(int typeStop)
            : base(x => x.IsDeleted == false && x.TypeStop == typeStop)
        {
            AddInclude(t => t.Reason);
            AddInclude(t => t.Concept);
            ApplyOrderByDescending(x => x.ValidityStartDate);
        }
    }
}
