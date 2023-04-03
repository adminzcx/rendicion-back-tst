using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.CashFormAggregate.MoneyType.Dtos;
using Prome.Viaticos.Server.Application.CashFormAggregate.MoneyType.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.MoneyType.Queries.GetAllMoneyTypes
{
    public class GetAllMoneyTypesQueryHandler : QueryHandler<GetAllMoneyTypesQuery, ICollection<MoneyTypeDto>>
    {
        public GetAllMoneyTypesQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<MoneyTypeDto>> Handle(GetAllMoneyTypesQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.CashFormAggregate.MoneyType>()
                .ListAsync(new MoneyTypesSpecification());

            return Map(list);
        }
    }
}
