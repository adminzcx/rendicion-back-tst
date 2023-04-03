using FluentValidation;

namespace Prome.Viaticos.Server.Application.DatosMillanAggregate.Commands.UpdateUser
{
    public class UpdateDatosMillanCommandValidator : AbstractValidator<UpdateDatosMillanCommand>
    {
        public UpdateDatosMillanCommandValidator()
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

            //RuleFor(v => v.Position)
            //   .NotNull()
            //   .NotEmpty();


        }

    }
}







