using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashConcept.Specifications
{
    public sealed class CashConceptSpecification : BaseSpecification<Domain.Entities.CashFormAggregate.CashConcept>
    {
        public CashConceptSpecification()
            : base()
        {
            ApplyOrderBy(x => x.Name);
        }
    }
}
