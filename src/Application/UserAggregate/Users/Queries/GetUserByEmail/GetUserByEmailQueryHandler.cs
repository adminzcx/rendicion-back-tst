using Ardalis.GuardClauses;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetUserByEmail
{

    public class GetUserLoggedHandler : QueryHandler<GetUserByEmailQuery, CurrentUserDto>
    {

        public GetUserLoggedHandler(
         IAsyncUnitOfWork unitOfWork,
         IMapper mapper)
         : base(unitOfWork, mapper)
        { }

        public override async Task<CurrentUserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {

            var entities = await _unitOfWork
              .Repository<User>()
              .ListAsync(new ByEmployeeEmailSpecification(request.Email));

            Guard.Against.Null(entities, nameof(request.Email));
            Guard.Against.IsValidUser(entities);

            var entity = entities.First();

            return Map(entity);
        }
    }
}
