using MediatR;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Commands.PathCashFormPaidStatus
{
    public class PathCashFormPaidStatusCommand : IRequest
    {
        public int Id { get; set; }
        public bool Paid { get; set; }
    }
}
