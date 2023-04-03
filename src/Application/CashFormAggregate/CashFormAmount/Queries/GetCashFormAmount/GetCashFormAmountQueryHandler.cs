using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Dtos;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Queries.GetCashFormAmount
{
    public class GetCashFormAmountQueryHandler : QueryHandler<GetCashFormAmountQuery, CashFormAmountDto>
    {
        public GetCashFormAmountQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<CashFormAmountDto> Handle(GetCashFormAmountQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.CashFormAggregate.CashFormAmount>()
                .SingleOrDefaultAsync(new CashFormAmountByIdSpecification(request.Id));

            return Map(list);
        }
    }
}
