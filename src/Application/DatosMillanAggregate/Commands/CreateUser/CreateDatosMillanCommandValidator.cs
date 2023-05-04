using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Prome.Viaticos.Server.Application.DatosMillanAggregate.Commands.CreateUser
{
    public class CreateDatosMillanCommandValidator : AbstractValidator<CreateDatosMillanCommand>
    {
        public CreateDatosMillanCommandValidator()
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
                        
        }
    }
}

