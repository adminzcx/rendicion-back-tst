using Prome.Viaticos.Server.Application._Common.Helpers.Query;
using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Specifications
{
    public sealed class LunchFormReportByStatusSpecification : BaseSpecification<Domain.Entities.LunchFormAggregate.LunchForm>
    {
        public LunchFormReportByStatusSpecification(long userId, int statusId, bool isPaid = false)
            : base(x => x.IsDeleted != true 
                        && x.Status.Id == statusId 
                        && x.User.Id == userId
                        && x.IsPaid == isPaid)
        {
            AddInclude(t => t.Status);
            AddInclude(t => t.Restaurant);
            AddInclude(t => t.Branch);
            AddInclude(t => t.Comments);
            AddInclude(t => t.Audits);
            AddIncludes(t => t.Include(o => o.User).ThenInclude(i => i.Branch));
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
