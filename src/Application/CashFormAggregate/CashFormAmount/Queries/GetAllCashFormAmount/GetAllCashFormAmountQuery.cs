using MediatR;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Queries.GetAllCashFormAmount
{
    public class GetAllCashFormAmountQuery : IRequest<ICollection<CashFormAmountListDto>>
    {

    }
}
