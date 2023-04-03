using MediatR;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
