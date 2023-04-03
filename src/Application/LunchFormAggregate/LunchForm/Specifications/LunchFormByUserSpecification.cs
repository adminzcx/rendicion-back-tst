using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Specifications
{
    public sealed class LunchFormByUserSpecification : BaseSpecification<Domain.Entities.LunchFormAggregate.LunchForm>
    {
        public LunchFormByUserSpecification(long userId)
            : base(x => x.User.Id == userId && x.IsDeleted != true)
        {
            AddInclude(t => t.Status);
            AddInclude(t => t.User);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
