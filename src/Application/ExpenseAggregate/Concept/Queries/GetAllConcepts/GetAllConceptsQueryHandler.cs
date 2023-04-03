using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Queries.GetAllConcepts
{

    public class GetAllConceptsQueryHandler : QueryHandler<GetAllConceptsQuery, ICollection<ConceptDto>>
    {
        public GetAllConceptsQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<ConceptDto>> Handle(GetAllConceptsQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.ExpenseAggregate.Concept>()
                .ListAllAsync();

            return Map(list);
        }
    }
}
