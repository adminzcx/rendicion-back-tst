using MediatR;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Dtos;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Queries.GetCashFormCapAmount
{
    public class GetCashFormCapAmountQuery : IRequest<CashFormCapAmountDto>
    {
        public int Id { get; set; }
    }
}
