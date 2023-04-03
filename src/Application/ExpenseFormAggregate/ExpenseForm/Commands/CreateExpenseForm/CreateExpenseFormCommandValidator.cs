using FluentValidation;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.CreateExpenseForm
{


    public class CreateExpenseFormCommandValidator : AbstractValidator<CreateExpenseFormCommand>
    {
        public CreateExpenseFormCommandValidator()
        {

            RuleFor(v => v.Email)
             .NotNull()
             .NotEmpty();

            RuleFor(v => v.Description)
            .MaximumLength(100);
        }
    }
}