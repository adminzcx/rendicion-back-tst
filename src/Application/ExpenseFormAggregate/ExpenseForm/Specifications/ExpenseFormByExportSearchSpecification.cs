using Prome.Viaticos.Server.Application._Common.Helpers.Query;
using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.ExpenseFormAggregate;
using Prome.Viaticos.Server.Domain.Enums;
using System;

namespace Prome.Viaticos.Server.Application.AdminAggregate.ExportSearch.Specification
{
    public sealed class ExpenseFormByExportSearchSpecification :
      BaseSpecification<ExpenseForm>
    {
        public ExpenseFormByExportSearchSpecification(DateTime startDate, DateTime endDate)
            : base(x => x.Status.Id == (int)ExpenseFormStatusEnum.Aprobado &&
             x.IsDeleted != true &&
            x.ApprovalDate >= startDate &&
            x.ApprovalDate <= endDate)
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