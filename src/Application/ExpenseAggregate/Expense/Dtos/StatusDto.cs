
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos
{

    public class ExpenseStatusDto : IMapFrom<ExpenseStatus>
    {
        public long Id { get; set; }

        public string Name { get; set; }

    }
}
