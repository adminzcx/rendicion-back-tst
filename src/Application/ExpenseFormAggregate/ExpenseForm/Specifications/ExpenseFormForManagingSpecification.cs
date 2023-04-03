using Prome.Viaticos.Server.Application._Common.Helpers.Query;
using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Enums;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Specifications
{
    public sealed class ExpenseFormForManagingSpecification : BaseSpecification<Domain.Entities.ExpenseFormAggregate.ExpenseForm>
    {
        public ExpenseFormForManagingSpecification(List<long> usersId, ExpenseFormStatusEnum status, bool isPaid = false)
            : base(x => x.IsDeleted != true 
                        && x.Status.Id == (int)status 
                        && usersId.Contains(x.User.Id)
                        && x.IsPaid == isPaid)
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
