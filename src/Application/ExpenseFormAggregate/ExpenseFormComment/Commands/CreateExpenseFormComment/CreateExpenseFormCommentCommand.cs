using MediatR;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseFormComment.Commands.CreateExpenseFormComment
{
    public class CreateExpenseFormCommentCommand : IRequest
    {
        public string Email { get; set; }

        public int ExpenseFormId { get; set; }

        public string Description { get; set; }

    }
}
