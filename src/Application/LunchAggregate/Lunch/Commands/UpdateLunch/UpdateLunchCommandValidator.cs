using FluentValidation;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Commands.UpdateLunch
{
    public class UpdateLunchCommandValidator : AbstractValidator<UpdateLunchCommand>
    {
        public UpdateLunchCommandValidator()
        {
            RuleFor(v => v.Id)
             .NotNull()
             .NotEmpty();

            RuleFor(v => v.Amount)
             .NotNull()
             .NotEmpty();

            RuleFor(v => v.UserId)
                .NotEmpty()
                .NotNull();

        }
    }
}