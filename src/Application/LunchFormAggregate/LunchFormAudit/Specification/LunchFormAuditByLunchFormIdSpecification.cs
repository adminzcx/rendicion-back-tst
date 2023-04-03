using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchFormAudit.Specifications
{
    public sealed class LunchFormAuditByLunchFormIdSpecification : BaseSpecification<Domain.Entities.LunchFormAggregate.LunchFormAudit>
    {
        public LunchFormAuditByLunchFormIdSpecification(long lunchFormId)
            : base(x => x.LunchForm.Id == lunchFormId)
        {
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
