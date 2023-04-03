using MediatR;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Dtos;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Queries.GetCashFormAmountByBranch
{
    public class GetCashFormAmountByBranchQuery : IRequest<CashFormAmountDto>
    {
        public string Email { get; set; }
    }
}
