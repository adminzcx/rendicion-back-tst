using MediatR;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAudit.Queries.GetAllCashFormAuditByCashFormId
{
    public class GetAllCashFormAuditByCashFormIdQuery : IRequest<ICollection<CashFormListDto>>
    {
        public int CashFormId { get; set; }
    }
}
