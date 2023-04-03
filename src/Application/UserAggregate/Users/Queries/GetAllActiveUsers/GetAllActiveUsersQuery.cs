using MediatR;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos;
using System;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetAllActiveUsers
{

    public class GetAllActiveUsersQuery : IRequest<ICollection<ActiveUserDto>>
    {
        public DateTime? Date { get; set; }
    }
}
