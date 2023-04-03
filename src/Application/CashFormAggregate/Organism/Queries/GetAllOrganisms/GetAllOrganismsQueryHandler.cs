using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.CashFormAggregate.Organism.Dtos;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.Organism.Queries.GetAllOrganisms
{
    public class GetAllOrganismsQueryHandler : QueryHandler<GetAllOrganismsQuery, ICollection<OrganismDto>>
    {
        public GetAllOrganismsQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<OrganismDto>> Handle(GetAllOrganismsQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.CashFormAggregate.Organism>()
                .ListAllAsync();

            return Map(list);
        }
    }
}
