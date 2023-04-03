using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Specifications
{
    public sealed class CashFormByUserSpecification : BaseSpecification<Domain.Entities.CashFormAggregate.CashForm>
    {
        public CashFormByUserSpecification(long userId)
            : base(x => x.User.Id == userId && x.IsDeleted != true)
        {
            AddInclude(t => t.Status);
            AddInclude(t => t.User);
            AddInclude(t => t.Cashes);
            AddInclude(t => t.Expenses);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
