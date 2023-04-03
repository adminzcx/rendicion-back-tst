using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashConcept.Dtos;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashConcept.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashConcept.Queries.GetAllCashConcepts
{
    public class GetAllCashConceptsQueryHandler : QueryHandler<GetAllCashConceptsQuery, ICollection<CashConceptDto>>
    {
        public GetAllCashConceptsQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<CashConceptDto>> Handle(GetAllCashConceptsQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.CashFormAggregate.CashConcept>()
                .ListAsync(new CashConceptSpecification());

            return Map(list);
        }
    }
}
