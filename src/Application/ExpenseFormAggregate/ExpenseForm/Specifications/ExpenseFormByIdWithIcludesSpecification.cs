
using Prome.Viaticos.Server.Application._Common.Helpers.Query;
using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Specifications
{

    public sealed class ExpenseFormByIdWithIcludesSpecification : BaseSpecification<Domain.Entities.ExpenseFormAggregate.ExpenseForm>
    {
        public ExpenseFormByIdWithIcludesSpecification(int id)
            : base(x => x.Id == id && x.IsDeleted != true)
        {
            AddInclude(t => t.Status);
            AddInclude(t => t.Expenses);
            AddInclude(t => t.Comments);
            AddIncludes(t => t.Include(o => o.User).ThenInclude(i => i.Position));
            AddIncludes(t => t.Include(o => o.User).ThenInclude(i => i.Management));
            AddIncludes(t => t.Include(o => o.User).ThenInclude(i => i.Sector));
            AddIncludes(t => t.Include(o => o.User).ThenInclude(i => i.Branch));
            ApplyOrderByDescending(x => x.Id);

        }
    }

}
