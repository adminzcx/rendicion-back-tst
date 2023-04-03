using MediatR;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.PathExpenseForm
{
    public class PathExpenseFormCommand : IRequest
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

    }
}
