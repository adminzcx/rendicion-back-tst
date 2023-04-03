using FluentValidation;
namespace Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Commands.DeleteUserSubstitution
{


    public class DeleteUserSubstitutionCommandValidator : AbstractValidator<DeleteUserSubstitutionCommand>
    {
        public DeleteUserSubstitutionCommandValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
