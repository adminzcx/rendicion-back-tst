using MediatR;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Commands.PathLunchFormPaidStatus
{
    public class PathLunchFormPaidStatusCommand : IRequest
    {
        public int Id { get; set; }
        public bool Paid { get; set; }
    }
}
