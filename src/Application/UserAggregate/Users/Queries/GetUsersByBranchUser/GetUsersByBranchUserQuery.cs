using MediatR;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetUsersByBranchUser
{
    public class GetUsersByBranchUserQuery : IRequest<ICollection<UserDto>>
    {
        public string Email { get; set; }
    }
}
