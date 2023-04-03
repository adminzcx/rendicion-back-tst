using Prome.Viaticos.Server.Application._Common.Specifications;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Specifications
{

    public sealed class ConceptByPositionSpecification : BaseSpecification<Domain.Entities.ExpenseAggregate.Concept>
    {
        public ConceptByPositionSpecification(int reasonId, List<long> enabledConcepts)
            : base(x => x.Reason.Id.Equals(reasonId) && enabledConcepts.Contains((x.Id)))
        {
            ApplyOrderBy(x => x.Name);
        }
    }
}
