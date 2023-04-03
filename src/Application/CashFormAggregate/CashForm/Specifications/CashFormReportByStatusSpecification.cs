using Prome.Viaticos.Server.Application._Common.Helpers.Query;
using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Specifications
{
    public sealed class CashFormReportByStatusSpecification : BaseSpecification<Domain.Entities.CashFormAggregate.CashForm>
    {
        public CashFormReportByStatusSpecification(long userId, int statusId)
            : base(x => x.IsDeleted != true 
                        && x.Status.Id == statusId
                        && x.User.Id == userId
                        && x.IsPaid==false)
        {
            AddInclude(t => t.Status);
            AddInclude(t => t.Branch);
            AddInclude(t => t.Comments);
            AddInclude(t => t.Audits);
            AddInclude(t => t.Organism);
            AddInclude(t => t.User);
            AddIncludes(t => t.Include(o => o.Cashes));
            AddIncludes(t => t.Include(o => o.User).ThenInclude(i => i.Branch));
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
