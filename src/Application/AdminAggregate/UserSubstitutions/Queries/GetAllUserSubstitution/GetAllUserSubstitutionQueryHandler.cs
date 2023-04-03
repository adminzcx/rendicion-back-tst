using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Dtos;
using Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Queries.GetAllUserSubstitution
{


    public class GetAllUserSubstitutionQueryHandler : QueryHandler<GetAllUserSubstitutionQuery, ICollection<UserSubstitutionDto>>
    {
        public GetAllUserSubstitutionQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<UserSubstitutionDto>> Handle(GetAllUserSubstitutionQuery request, CancellationToken cancellationToken)
        {

            var list = await _unitOfWork
             .Repository<UserSubstitution>()
             .ListAsync(new UserSubstitutionEnabledSpecification());


            return Map(list);
        }
    }
}
