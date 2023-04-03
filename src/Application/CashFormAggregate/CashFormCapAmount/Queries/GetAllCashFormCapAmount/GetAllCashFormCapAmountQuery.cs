using System.Collections.Generic;
using MediatR;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Dtos;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Queries.GetAllCashFormCapAmount
{
    public class GetAllCashFormCapAmountQuery : IRequest<ICollection<CashFormCapAmountListDto>>
    { 
    }
}
