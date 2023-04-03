using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Dtos;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Queries.GetAllCashFormAmount
{
    public class GetAllCashFormAmountQueryHandler : QueryHandler<GetAllCashFormAmountQuery, ICollection<CashFormAmountListDto>>
    {
        public GetAllCashFormAmountQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper
           )
            : base(unitOfWork, mapper)
        {
        }

        public override async Task<ICollection<CashFormAmountListDto>> Handle(GetAllCashFormAmountQuery request, CancellationToken cancellationToken)
        {

            var list = await _unitOfWork
             .Repository<Domain.Entities.CashFormAggregate.CashFormAmount>()
             .ListAsync(new CashFormAmountSpecification());

            return Map(list);
        }
    }
}
