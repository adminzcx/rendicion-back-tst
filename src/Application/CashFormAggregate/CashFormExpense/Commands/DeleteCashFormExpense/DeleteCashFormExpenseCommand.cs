using MediatR;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Commands.DeleteCashFormExpense
{

    public class DeleteECashFormExpenseCommand : IRequest
    {
        public int Id { get; set; }
    }
}
