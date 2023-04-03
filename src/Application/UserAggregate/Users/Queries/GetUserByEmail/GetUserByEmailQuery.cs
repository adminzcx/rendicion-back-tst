using MediatR;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetUserByEmail
{


    public class GetUserByEmailQuery : IRequest<CurrentUserDto>
    {
        public string Email { get; set; }

    }
}
