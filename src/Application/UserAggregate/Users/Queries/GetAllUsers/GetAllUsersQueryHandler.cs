using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetAllUsers
{

    public class GetAllUsersQueryHandler : QueryHandler<GetAllUsersQuery, ICollection<UserDto>>
    {
        public GetAllUsersQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {

            var list = await _unitOfWork
             .Repository<User>()
             .ListAllAsync();


            return Map(list);
        }
    }

}
