using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos
{

    public class ExpenseAdviceDto : IMapFrom<ExpenseAdvice>
    {

        public string Title { get; set; }

        public string Description { get; set; }

    }
}
