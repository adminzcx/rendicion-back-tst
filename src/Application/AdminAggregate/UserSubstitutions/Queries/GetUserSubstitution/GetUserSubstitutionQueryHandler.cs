using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Queries.GetUserSubstitution
{


    public class GetUserSubstitutionQueryHandler : QueryHandler<GetUserSubstitutionQuery, UserDto>
    {
        public GetUserSubstitutionQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<UserDto> Handle(GetUserSubstitutionQuery request, CancellationToken cancellationToken)
        {
            var vm = await _unitOfWork
                .Repository<User>()
                .GetByIdAsync(request.Id);

            return Map(vm);
        }
    }
}
