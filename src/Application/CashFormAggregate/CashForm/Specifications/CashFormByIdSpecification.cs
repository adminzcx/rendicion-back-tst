using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Specifications
{
    public sealed class CashFormByIdSpecification : BaseSpecification<Domain.Entities.CashFormAggregate.CashForm>
    {
        public CashFormByIdSpecification(long id)
            : base(x => x.Id == id && x.IsDeleted != true)
        {
            AddInclude(t => t.Status);
            AddInclude(t => t.User);
            AddInclude(t => t.Cashes);
            AddInclude(t => t.Expenses);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
