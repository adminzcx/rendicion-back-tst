using MediatR;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GetExpenseForm
{

    public class GetExpenseFormQuery : IRequest<ExpenseFormDto>
    {
        public int Id { get; set; }
    }
}
