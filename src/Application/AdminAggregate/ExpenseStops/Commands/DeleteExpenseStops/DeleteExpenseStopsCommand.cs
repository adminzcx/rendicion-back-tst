using MediatR;

namespace Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Commands.DeleteExpenseStops
{

    public class DeleteExpenseStopsCommand : IRequest
    {
        public int Id { get; set; }
    }
}
