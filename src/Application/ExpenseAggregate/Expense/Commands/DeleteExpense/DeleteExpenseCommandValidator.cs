using FluentValidation;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Commands.DeleteExpense
{

    public class DeleteExpenseCommandValidator : AbstractValidator<DeleteExpenseCommand>
    {
        public DeleteExpenseCommandValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
