using FluentValidation;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Commands.DeleteLunch
{
    public class DeleteLunchCommandHandlerValidator : AbstractValidator<DeleteLunchCommand>
    {
        public DeleteLunchCommandHandlerValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
