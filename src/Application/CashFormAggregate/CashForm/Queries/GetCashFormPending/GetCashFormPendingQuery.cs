using MediatR;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Dtos;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetCashFormPending
{
    public class GetCashFormPendingQuery : IRequest<CashFormDto>
    {
        public string Email { get; set; }
        public int StatusId { get; set; }
    }
}
