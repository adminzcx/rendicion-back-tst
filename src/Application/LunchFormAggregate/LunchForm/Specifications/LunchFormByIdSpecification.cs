using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Specifications
{
    public sealed class LunchFormByIdSpecification : BaseSpecification<Domain.Entities.LunchFormAggregate.LunchForm>
    {
        public LunchFormByIdSpecification(long id)
            : base(x => x.Id == id && x.IsDeleted != true)
        {
            AddInclude(t => t.Status);
            AddInclude(t => t.User);
            AddInclude(t => t.Lunches);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
