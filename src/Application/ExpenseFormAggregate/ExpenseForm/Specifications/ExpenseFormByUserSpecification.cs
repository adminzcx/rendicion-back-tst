using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Specifications
{
    public sealed class ExpenseFormByUserSpecification : BaseSpecification<Domain.Entities.ExpenseFormAggregate.ExpenseForm>
    {
        public ExpenseFormByUserSpecification(long userId)
            : base(x => x.User.Id == userId && x.IsDeleted != true)
        {
            AddInclude(t => t.Status);
            AddInclude(t => t.User);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
