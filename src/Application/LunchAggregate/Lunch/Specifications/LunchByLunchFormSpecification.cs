using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Specifications
{
    public sealed class LunchByLunchFormSpecification : BaseSpecification<Domain.Entities.LunchAggregate.Lunch>
    {
        public LunchByLunchFormSpecification(long userId, long lunchFormId)
            : base(x => x.CreatedUser.Id == userId && x.IsDeleted != true
            && x.LunchForm != null && x.LunchForm.Id == lunchFormId)
        {
            AddInclude(t => t.LunchForm);
            AddInclude(t => t.User);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
