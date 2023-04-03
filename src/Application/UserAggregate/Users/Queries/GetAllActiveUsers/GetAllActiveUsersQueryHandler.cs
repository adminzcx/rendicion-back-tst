using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetAllActiveUsers
{

    public class GetAllActiveUsersQueryHandler : QueryHandler<GetAllActiveUsersQuery, ICollection<ActiveUserDto>>
    {
        private readonly IDateTime _dateTimeService;

        public GetAllActiveUsersQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper,
            IDateTime dateTimeService)
            : base(unitOfWork, mapper)
        {
            _dateTimeService = dateTimeService;
        }

        public override async Task<ICollection<ActiveUserDto>> Handle(GetAllActiveUsersQuery request, CancellationToken cancellationToken)
        {
            var filterDate = request.Date ?? _dateTimeService.Now;

            var list = await _unitOfWork
             .Repository<User>()
             .ListAsync(new ByEmployeeDisabledDateSpecification(filterDate));

            return Map(list);
        }
    }
}
