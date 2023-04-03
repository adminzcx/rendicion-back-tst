using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Specifications
{
    public sealed class LunchByIdSpecification : BaseSpecification<Domain.Entities.LunchAggregate.Lunch>
    {
        public LunchByIdSpecification(long id)
            : base(x => x.Id == id)
        {
            AddInclude(t => t.User);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
