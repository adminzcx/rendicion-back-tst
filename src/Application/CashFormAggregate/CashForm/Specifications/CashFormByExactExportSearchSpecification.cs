using System;
using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Enums;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Specifications
{
    public class CashFormByExactExportSearchSpecification :
      BaseSpecification<Domain.Entities.CashFormAggregate.CashForm>
    {
        public CashFormByExactExportSearchSpecification(DateTime startDate)
            : base(x => x.Status.Id == (int)CashFormStatusEnum.Aprobado &&
             x.IsDeleted != true &&
            x.ApprovalDate.Date == startDate.Date)
        {
            AddInclude(t => t.Status);
            AddInclude(t => t.User);
            AddInclude(t => t.Cashes);
            AddInclude(t => t.Expenses);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
