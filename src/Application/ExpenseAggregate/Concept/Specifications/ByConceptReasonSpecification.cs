
using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Specifications
{
    public sealed class ByConceptReasonSpecification : BaseSpecification<Domain.Entities.ExpenseAggregate.Concept>
    {
        public ByConceptReasonSpecification(int reasonId)
            : base(x => x.Reason.Id.Equals(reasonId))
        {
            Includes.Add(x => x.Reason);
            ApplyOrderBy(x => x.Name);
        }
    }
}
