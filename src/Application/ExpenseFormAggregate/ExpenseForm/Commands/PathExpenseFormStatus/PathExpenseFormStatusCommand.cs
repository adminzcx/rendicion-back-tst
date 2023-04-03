using MediatR;
using Prome.Viaticos.Server.Domain.Enums;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.PathExpenseFormStatus
{
    public class PathExpenseFormStatusCommand : IRequest
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public ExpenseFormStatusEnum Status { get; set; }

        public bool ToReview { get; set; }

        public bool ToReject1 { get; set; }

        public bool ToReject2 { get; set; }


    }
}
