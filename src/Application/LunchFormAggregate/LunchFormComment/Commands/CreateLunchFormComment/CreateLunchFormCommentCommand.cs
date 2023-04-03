using MediatR;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchFormComment.Commands.CreateLunchFormComment
{
    public class CreateLunchFormCommentCommand : IRequest
    {
        public string Email { get; set; }

        public int ExpenseFormId { get; set; }

        public string Description { get; set; }

    }
}
