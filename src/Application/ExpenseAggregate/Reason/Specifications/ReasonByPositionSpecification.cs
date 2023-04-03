
using Prome.Viaticos.Server.Application._Common.Specifications;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Reason.Specifications
{


    public sealed class ReasonByPositionSpecification : BaseSpecification<Domain.Entities.ExpenseAggregate.Reason>
    {
        public ReasonByPositionSpecification(List<long> reasonIdValid)
            : base(x => reasonIdValid.Contains(x.Id))
        {
            Includes.Add(x => x.Concepts);
            ApplyOrderBy(x => x.Name);
        }
    }
}
