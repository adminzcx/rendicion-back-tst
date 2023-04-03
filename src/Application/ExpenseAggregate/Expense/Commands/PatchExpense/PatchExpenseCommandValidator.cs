using FluentValidation;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Commands.PatchExpense
{

    public class PatchUserCommandValidator : AbstractValidator<PatchExpenseCommand>
    {
        public PatchUserCommandValidator()
        {
            RuleFor(v => v.StatusId)
             .NotNull()
             .NotEmpty();
        }
    }
}
