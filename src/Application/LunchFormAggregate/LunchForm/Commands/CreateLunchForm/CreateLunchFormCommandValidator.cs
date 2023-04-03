using FluentValidation;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Commands.CreateLunchForm
{
    public class CreateLunchFormCommandValidator : AbstractValidator<CreateLunchFormCommand>
    {
        public CreateLunchFormCommandValidator()
        {
            RuleFor(v => v.RestaurantId)
             .NotNull()
             .NotEmpty();

            RuleFor(v => v.Cai)
             .NotNull()
             .NotEmpty();

            RuleFor(v => v.InvoiceType)
             .NotNull()
             .NotEmpty();

            RuleFor(v => v.InvoiceNumber)
             .NotNull()
             .NotEmpty();

            RuleFor(v => v.NumberOfTickets)
             .NotNull()
             .NotEmpty();

            RuleFor(v => v.Subtotal)
             .NotNull()
             .NotEmpty();

            RuleFor(v => v.Iva)
             .NotNull()
             .NotEmpty();

            RuleFor(v => v.Total)
             .NotNull()
             .NotEmpty();

            RuleFor(v => v.BussinesDays)
             .NotNull()
             .NotEmpty();
        }
    }
}
