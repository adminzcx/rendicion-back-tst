using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Enums;
using System;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Specifications
{
    public class CashFormByExportSearchSpecification :
      BaseSpecification<Domain.Entities.CashFormAggregate.CashForm>
    {
        public CashFormByExportSearchSpecification(DateTime startDate, DateTime endDate)
            : base(x => x.Status.Id == (int)CashFormStatusEnum.Aprobado &&
             x.IsDeleted != true &&
            x.ApprovalDate >= startDate &&
            x.ApprovalDate <= endDate)
        {
            AddInclude(t => t.Status);
            AddInclude(t => t.User);
            AddInclude(t => t.Cashes);
            AddInclude(t => t.Expenses);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
