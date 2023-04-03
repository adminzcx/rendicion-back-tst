using MediatR;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Commands.DeleteCashFormAmount
{
    public class DeleteCashFormAmountCommand : IRequest
    {
        public long Id { get; set; }
    }
}
