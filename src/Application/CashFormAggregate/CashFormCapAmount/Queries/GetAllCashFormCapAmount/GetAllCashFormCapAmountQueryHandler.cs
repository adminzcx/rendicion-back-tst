using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Dtos;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Queries.GetAllCashFormCapAmount
{
    public class GetAllCashFormCapAmountQueryHandler : QueryHandler<GetAllCashFormCapAmountQuery, ICollection<CashFormCapAmountListDto>>
    {
        public GetAllCashFormCapAmountQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper
           )
            : base(unitOfWork, mapper)
        {
        }

        public override async Task<ICollection<CashFormCapAmountListDto>> Handle(GetAllCashFormCapAmountQuery request, CancellationToken cancellationToken)
        {

            var list = await _unitOfWork
             .Repository<Domain.Entities.CashFormAggregate.CashFormCapAmount>()
             .ListAsync(new CashFormCapAmountSpecification());

            return Map(list);
        }
    }
}
