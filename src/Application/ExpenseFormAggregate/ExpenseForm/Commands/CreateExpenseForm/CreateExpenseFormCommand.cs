using MediatR;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.CreateExpenseForm
{

    public class CreateExpenseFormCommand : IRequest
    {
        public string Email { get; set; }

        public string Description { get; set; }

    }
}
