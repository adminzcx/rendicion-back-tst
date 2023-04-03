using Ardalis.GuardClauses;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Dtos;
using Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Specifications;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Queries.GetByLunchForm
{
    public class GetByLunchFormQueryHandler : QueryHandler<GetByLunchFormQuery, ICollection<LunchDto>>
    {
        public GetByLunchFormQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<LunchDto>> Handle(GetByLunchFormQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await this.GetCurrentUserAsync(request.Email);

            var list = await _unitOfWork
                .Repository<Domain.Entities.LunchAggregate.Lunch>()
                .ListAsync(new LunchByLunchFormSpecification(currentUser.Id, request.LunchFormId));

            return Map(list);
        }

        private async Task<User> GetCurrentUserAsync(string email)
        {
            var users = await _unitOfWork
                 .Repository<User>()
                 .ListAsync(new ByEmployeeEmailSpecification(email));

            Guard.Against.Null(users, nameof(email));
            Guard.Against.IsValidUser(users);

            return users.First();
        }
    }
}
