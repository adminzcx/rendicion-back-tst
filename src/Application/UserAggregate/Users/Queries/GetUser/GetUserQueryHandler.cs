using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetUser
{

    public class GetUserQueryHandler : QueryHandler<GetUserQuery, UserDto>
    {
        public GetUserQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var vm = await _unitOfWork
                .Repository<User>()
                .GetByIdAsync(request.Id);

            return Map(vm);
        }
    }
}
