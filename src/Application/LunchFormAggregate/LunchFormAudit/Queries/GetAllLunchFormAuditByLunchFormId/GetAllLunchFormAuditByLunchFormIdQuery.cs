using MediatR;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchFormAudit.Queries.GetAllLunchFormAuditByLunchFormId
{

    public class GetAllLunchFormAuditByLunchFormIdQuery : IRequest<ICollection<LunchFormListDto>>
    {
        public int ExpenseFormId { get; set; }

    }
}
