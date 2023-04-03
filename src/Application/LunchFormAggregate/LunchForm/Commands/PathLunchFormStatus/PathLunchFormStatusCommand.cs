using MediatR;
using Prome.Viaticos.Server.Domain.Enums;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Commands.PathLunchFormStatus
{
    public class PathLunchFormStatusCommand : IRequest
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public LunchFormStatusEnum Status { get; set; }

        public bool ToReview { get; set; }

        public bool ToReject { get; set; }
    }
}
