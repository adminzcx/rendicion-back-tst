using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Source.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Source.Queries.GetAllSources
{


    public class GetAllSourcesQueryHandler : QueryHandler<GetAllSourcesQuery, ICollection<SourceDto>>
    {
        public GetAllSourcesQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<SourceDto>> Handle(GetAllSourcesQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.ExpenseAggregate.Source>()
                .ListAllAsync();

            return Map(list);
        }
    }
}
