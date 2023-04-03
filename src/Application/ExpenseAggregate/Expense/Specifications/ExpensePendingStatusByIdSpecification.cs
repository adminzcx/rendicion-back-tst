using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Enums;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Specifications
{

    public class ExpensePendingStatusByIdSpecification : BaseSpecification<Domain.Entities.ExpenseAggregate.Expense>
    {
        public ExpensePendingStatusByIdSpecification(int id)
            : base(x => x.Status.Id == (int)ExpenseStatusEnum.Pendiente && x.ExpenseForm.Id == id && x.IsDeleted != true)
        {

        }
    }
}
