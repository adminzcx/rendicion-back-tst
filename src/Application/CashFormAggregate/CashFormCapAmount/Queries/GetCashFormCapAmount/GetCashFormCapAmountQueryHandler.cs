using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Dtos;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Queries.GetCashFormCapAmount
{
    public class GetCashFormCapAmountQueryHandler : QueryHandler<GetCashFormCapAmountQuery, CashFormCapAmountDto>
    {
        public GetCashFormCapAmountQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<CashFormCapAmountDto> Handle(GetCashFormCapAmountQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.CashFormAggregate.CashFormCapAmount>()
                .SingleOrDefaultAsync(new CashFormCapAmountByIdSpecification(request.Id));

            return Map(list);
        }
    }
}
