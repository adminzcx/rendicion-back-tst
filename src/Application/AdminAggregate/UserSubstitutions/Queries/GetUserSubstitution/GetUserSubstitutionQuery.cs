using MediatR;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos;

namespace Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Queries.GetUserSubstitution
{


    public class GetUserSubstitutionQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
