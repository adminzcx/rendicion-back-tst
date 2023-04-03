using MediatR;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Dtos;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Queries.GetCashFormAmount
{
    public class GetCashFormAmountQuery : IRequest<CashFormAmountDto>
    {
        public int Id { get; set; }
    }
}
