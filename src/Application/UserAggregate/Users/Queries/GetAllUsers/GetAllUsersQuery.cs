using MediatR;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetAllUsers
{

    public class GetAllUsersQuery : IRequest<ICollection<UserDto>>
    {
    }
}
