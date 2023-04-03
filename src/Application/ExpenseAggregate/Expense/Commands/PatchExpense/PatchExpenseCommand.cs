using MediatR;
using Prome.Viaticos.Server.Domain.Enums;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Commands.PatchExpense
{
    public class PatchExpenseCommand : IRequest
    {
        public int Id { get; set; }

        public int? RejectReasonId { get; set; }

        public ExpenseStatusEnum StatusId { get; set; }

        public bool ToApprove { get; set; }

        public bool ToRevert { get; set; }

        public bool ToReject { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }
    }
}
