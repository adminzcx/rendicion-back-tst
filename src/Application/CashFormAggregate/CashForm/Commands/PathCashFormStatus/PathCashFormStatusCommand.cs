using MediatR;
using Prome.Viaticos.Server.Domain.Enums;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Commands.PathCashFormStatus
{
    public class PathCashFormStatusCommand : IRequest
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public CashFormStatusEnum Status { get; set; }

        public bool ToReview { get; set; }

        public bool ToReject { get; set; }
    }
}

