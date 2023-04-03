using MediatR;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.PathExpenseFormPaidStatus
{
    public class PathExpenseFormPaidStatusCommand : IRequest
    {
        public int Id { get; set; }
        public bool Paid { get; set; }
    }
}
