

using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.ExpenseFormAggregate;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos
{
    public class ExpenseFormStatusDto : IMapFrom<ExpenseFormStatus>
    {
        public long Id { get; set; }

        public string Name { get; set; }

    }
}
