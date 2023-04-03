using FluentValidation;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Commands.UpdateCashFormExpense
{
    public class UpdateCashFormExpenseCommandValidator : AbstractValidator<UpdateCashFormExpenseCommand>
    {
        public UpdateCashFormExpenseCommandValidator()
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
