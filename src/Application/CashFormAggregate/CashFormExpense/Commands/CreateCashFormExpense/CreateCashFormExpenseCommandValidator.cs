using FluentValidation;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Commands.CreateCashFormExpense
{
    public class CreateCashFormExpenseCommandValidator : AbstractValidator<CreateCashFormExpenseCommand>
    {
        public CreateCashFormExpenseCommandValidator()
        {
            RuleFor(v => v.CashConceptId)
             .NotNull()
             .NotEmpty();

            RuleFor(v => v.Total)
             .NotNull()
             .NotEmpty();


        }
    }
}
