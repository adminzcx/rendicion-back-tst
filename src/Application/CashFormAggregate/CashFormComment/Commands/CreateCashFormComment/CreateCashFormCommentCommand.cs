using MediatR;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormComment.Commands.CreateCashFormComment
{
    public class CreateCashFormCommentCommand : IRequest
    {
        public string Email { get; set; }

        public int ExpenseFormId { get; set; }

        public string Description { get; set; }

    }
}