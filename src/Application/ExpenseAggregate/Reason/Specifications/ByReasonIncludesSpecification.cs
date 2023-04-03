using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Reason.Specifications
{


    public sealed class ByReasonIncludesSpecification : BaseSpecification<Domain.Entities.ExpenseAggregate.Reason>
    {
        public ByReasonIncludesSpecification()
            : base()
        {
            Includes.Add(x => x.Concepts);
            ApplyOrderBy(x => x.Name);
        }
    }
}
