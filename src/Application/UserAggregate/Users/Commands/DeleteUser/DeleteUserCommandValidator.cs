using FluentValidation;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Commands.DeleteUser
{

    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(t => t.EmployeeRecord)
                .NotEmpty()
                .NotNull();
        }
    }
}
