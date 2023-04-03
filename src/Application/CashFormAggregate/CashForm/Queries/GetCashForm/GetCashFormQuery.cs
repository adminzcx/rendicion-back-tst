using MediatR;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Dtos;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetCashForm
{
    public class GetCashFormQuery : IRequest<CashFormDto>
    {
        public int Id { get; set; }
    }
}
