using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Specifications
{
    public sealed class LunchByUserSpecification : BaseSpecification<Domain.Entities.LunchAggregate.Lunch>
    {
        public LunchByUserSpecification(long userId)
            : base(x => x.CreatedUser.Id == userId && x.IsDeleted != true && x.LunchForm == null)
        {
            AddInclude(t => t.LunchForm);
            AddInclude(t => t.User);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
