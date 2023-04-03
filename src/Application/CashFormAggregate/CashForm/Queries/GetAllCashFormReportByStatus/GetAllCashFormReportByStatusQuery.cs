using MediatR;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetAllCashFormReportByStatus
{
    public class GetAllCashFormReportByStatusQuery : IRequest<ICollection<CashFormReportDto>>
    {
        public string Email { get; set; }
        public int StatusId { get; set; }
    }
}
