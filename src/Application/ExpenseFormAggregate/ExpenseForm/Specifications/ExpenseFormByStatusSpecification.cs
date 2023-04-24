using Prome.Viaticos.Server.Application._Common.Helpers.Query;
using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Specifications
{

    public sealed class ExpenseFormByStatusSpecification : BaseSpecification<Domain.Entities.ExpenseFormAggregate.ExpenseForm>
    {
        public ExpenseFormByStatusSpecification(long userId, int statusId)
            : base(x => x.IsDeleted != true && x.Status.Id == statusId && x.User.Id == userId)
        {
            AddInclude(t => t.Status);
            AddIncludes(t => t.Include(o => o.User).ThenInclude(i => i.Position));
            AddIncludes(t => t.Include(o => o.User).ThenInclude(i => i.Management));
            AddIncludes(t => t.Include(o => o.User).ThenInclude(i => i.Sector));
            AddIncludes(t => t.Include(o => o.User).ThenInclude(i => i.Branch));
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
