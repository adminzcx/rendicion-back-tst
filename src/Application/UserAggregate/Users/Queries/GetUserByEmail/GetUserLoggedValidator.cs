using FluentValidation;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetUserByEmail
{

    public class GetUserLoggedValidator : AbstractValidator<GetUserByEmailQuery>
    {
        public GetUserLoggedValidator()
        {
            RuleFor(v => v.Email).NotEmpty();
        }
    }
}
