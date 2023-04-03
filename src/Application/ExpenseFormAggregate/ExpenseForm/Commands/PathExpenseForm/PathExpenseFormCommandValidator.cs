using FluentValidation;
namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.PathExpenseForm
{

    public class PathExpenseFormCommandValidator : AbstractValidator<PathExpenseFormCommand>
    {
        public PathExpenseFormCommandValidator()
        {

            RuleFor(v => v.Description)
             .MaximumLength(100);
        }
    }
}