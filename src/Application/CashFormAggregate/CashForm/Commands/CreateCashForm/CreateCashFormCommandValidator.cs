using FluentValidation;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Commands.CreateCashForm
{
    public class CreateCashFormCommandValidator : AbstractValidator<CreateCashFormCommand>
    {
        public CreateCashFormCommandValidator()
        {
            RuleFor(v => v.BranchId)
             .NotNull()
             .NotEmpty();

            RuleFor(v => v.Total)
             .NotNull()
             .NotEmpty();

            RuleFor(v => v.OrganismId)
             .NotNull()
             .NotEmpty();


        }
    }
}
