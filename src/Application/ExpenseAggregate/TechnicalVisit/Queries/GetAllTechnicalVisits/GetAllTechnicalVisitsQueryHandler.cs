using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.TechnicalVisit.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.TechnicalVisit.Queries.GetAllTechnicalVisits
{

    public class GetAllTechnicalVisitsQueryHandler : QueryHandler<GetAllTechnicalVisitsQuery, ICollection<TechnicalVisitDto>>
    {
        public GetAllTechnicalVisitsQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<TechnicalVisitDto>> Handle(GetAllTechnicalVisitsQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.ExpenseAggregate.TechnicalVisit>()
                .ListAllAsync();

            return Map(list);
        }
    }
}
