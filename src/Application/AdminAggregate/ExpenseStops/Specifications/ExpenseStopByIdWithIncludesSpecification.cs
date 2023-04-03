using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Specifications
{
    public sealed class ExpenseStopByIdWithIncludesSpecification : BaseSpecification<Domain.Entities.AdminAggregate.ExpenseStops>
    {
        public ExpenseStopByIdWithIncludesSpecification(long id)
            : base(x => x.Id == id)
        {

            AddInclude(t => t.Reason);
            AddInclude(t => t.Concept);
        }
    }
}
