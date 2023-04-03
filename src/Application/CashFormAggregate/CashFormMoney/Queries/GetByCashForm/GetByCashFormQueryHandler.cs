using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormMoney.Dtos;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormMoney.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormMoney.Queries.GetByCashForm
{
    public class GetByCashFormQueryHandler : QueryHandler<GetByCashFormQuery, ICollection<CashFormMoneyDto>>
    {
        public GetByCashFormQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<CashFormMoneyDto>> Handle(GetByCashFormQuery request, CancellationToken cancellationToken)
        {

            var list = await _unitOfWork
                .Repository<Domain.Entities.CashFormAggregate.CashFormMoney>()
                .ListAsync(new MoneyByCashFormSpecification(request.CashFormId));

            return Map(list);
        }


    }
}
