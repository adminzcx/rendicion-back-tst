using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Dtos;
using Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Queries.GetAllExpenseStops
{
    public class GetAllExpenseStopsQueryHandler : QueryHandler<GetAllExpenseStopsQuery, ICollection<StopsListDto>>
    {


        public GetAllExpenseStopsQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper
           )
            : base(unitOfWork, mapper)
        {
        }

        public override async Task<ICollection<StopsListDto>> Handle(GetAllExpenseStopsQuery request, CancellationToken cancellationToken)
        {

            var list = await _unitOfWork
             .Repository<Domain.Entities.AdminAggregate.ExpenseStops>()
             .ListAsync(new ExpenseStopByTypeSpecification(request.TypeStopId));

            return Map(list);
        }
    }
}
