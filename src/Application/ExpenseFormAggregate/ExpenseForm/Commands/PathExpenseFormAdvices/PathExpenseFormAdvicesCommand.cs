using MediatR;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.PathExpenseFormAdvices
{
    public class PathExpenseFormAdvicesCommand : IRequest
    {

        public int Id { get; set; }

        public string Email { get; set; }

    }

}
