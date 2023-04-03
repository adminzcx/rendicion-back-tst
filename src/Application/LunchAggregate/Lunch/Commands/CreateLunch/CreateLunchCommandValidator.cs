using FluentValidation;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Commands.CreateLunch
{
    public class CreateLunchCommandValidator : AbstractValidator<CreateLunchCommand>
    {
        public CreateLunchCommandValidator()
        {
            RuleFor(v => v.Amount)
             .NotNull()
             .NotEmpty();

            RuleFor(v => v.UserId)
                .NotNull()
                .NotEmpty();


        }
    }
}
