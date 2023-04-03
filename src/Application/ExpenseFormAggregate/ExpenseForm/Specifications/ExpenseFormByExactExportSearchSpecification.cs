using System;
using Prome.Viaticos.Server.Application._Common.Helpers.Query;
using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Enums;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Specifications
{
    public  class ExpenseFormByExactExportSearchSpecification :
      BaseSpecification<Domain.Entities.ExpenseFormAggregate.ExpenseForm>
    {
        public ExpenseFormByExactExportSearchSpecification(DateTime startDate)
            : base(x => x.Status.Id == (int)ExpenseFormStatusEnum.Aprobado &&
             x.IsDeleted != true &&
            x.ApprovalDate.Date == startDate.Date )
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
