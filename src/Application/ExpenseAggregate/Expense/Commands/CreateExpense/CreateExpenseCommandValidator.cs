using FluentValidation;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Commands.CreateExpense
{

    public class CreateExpenseCommandValidator : AbstractValidator<CreateExpenseCommand>
    {
        public CreateExpenseCommandValidator()
        {

            RuleFor(v => v.ReasonId)
             .NotNull()
             .NotEmpty();

            RuleFor(v => v.ConceptId)
            .NotNull()
            .NotEmpty();

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