using FluentValidation;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Commands.UpdateExpense
{

    public class UpdateExpenseCommandValidator : AbstractValidator<UpdateExpenseCommand>
    {
        public UpdateExpenseCommandValidator()
        {

            RuleFor(v => v.PresentationDate)
            .NotNull()
            .NotEmpty();

            RuleFor(v => v.ExpenseDate)
            .NotNull()
            .NotEmpty();

            RuleFor(v => v.Description)
            .MaximumLength(100);
        }
    }
}
