using FluentValidation;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Commands.PatchUser
{

    public class PatchUserCommandValidator : AbstractValidator<PatchUserCommand>
    {
        public PatchUserCommandValidator()
        {
            RuleFor(v => v.EmployeeRecord)
             .NotNull()
             .NotEmpty()
             .MaximumLength(100);

            RuleFor(v => v.FirstName)
               .MaximumLength(100);

            RuleFor(v => v.LastName)
               .MaximumLength(100);

            RuleFor(v => v.Email)
               .MaximumLength(100)
               .EmailAddress();
        }
    }
}
