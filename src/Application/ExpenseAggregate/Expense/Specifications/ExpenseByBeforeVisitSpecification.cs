
using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Specifications
{

    public sealed class ExpenseByBeforeVisitSpecification : BaseSpecification<Domain.Entities.ExpenseAggregate.Expense>
    {
        public ExpenseByBeforeVisitSpecification(long userId)
            : base(x => (x.Latitude.HasValue && x.Latitude != 0) &&
                  (x.Longitude.HasValue && x.Longitude != 0)
                  && x.User.Id == userId)
        {
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
