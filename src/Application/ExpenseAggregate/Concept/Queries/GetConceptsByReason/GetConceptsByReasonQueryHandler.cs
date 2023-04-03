using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Dtos;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Specifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Queries.GetConceptsByReason
{

    public class GetConceptsByReasonQueryHandler : QueryHandler<GetConceptsByReasonQuery, ICollection<ConceptDto>>
    {
        public GetConceptsByReasonQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<ConceptDto>> Handle(GetConceptsByReasonQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.ExpenseAggregate.Concept>()
                .ListAsync(new ByConceptReasonSpecification(request.ReasonId));

            return Map(list);
        }
    }
}
