using FluentValidation;
namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Commands.UpdateUser
{


    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(v => v.EmployeeRecord)
              .NotNull()
              .NotEmpty()
              .MaximumLength(100);

            RuleFor(v => v.FirstName)
               .NotNull()
               .NotEmpty()
               .MaximumLength(100);

            RuleFor(v => v.LastName)
               .NotNull()
               .NotEmpty()
               .MaximumLength(100);

            RuleFor(v => v.Email)
               .NotNull()
               .NotEmpty()
               .MaximumLength(100)
               .EmailAddress();

            RuleFor(v => v.Position)
               .NotNull()
               .NotEmpty();

            RuleFor(v => v.BusinessUnit)
               .NotNull()
               .NotEmpty();

            RuleFor(v => v.BranchFrom)
               .NotNull()
               .NotEmpty();
        }
    }
}
