using MediatR;
using Prome.Viaticos.Server.Application.CashFormAggregate.MoneyType.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.MoneyType.Queries.GetAllMoneyTypes
{
    public class GetAllMoneyTypesQuery : IRequest<ICollection<MoneyTypeDto>>
    {
    }
}
