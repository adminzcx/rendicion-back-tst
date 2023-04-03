using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Specifications
{
    public sealed class ExpenseStopByConceptSpecification : BaseSpecification<Domain.Entities.AdminAggregate.ExpenseStops>
    {
        public ExpenseStopByConceptSpecification(long conceptId)
            : base(x => x.IsDeleted == false && x.Concept.Id == conceptId)
        {
        }
    }
}
