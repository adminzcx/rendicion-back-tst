using MediatR;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormMoney.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormMoney.Queries.GetByCashForm
{
    public class GetByCashFormQuery : IRequest<ICollection<CashFormMoneyDto>>
    {
        public int CashFormId { get; set; }
    }
}
