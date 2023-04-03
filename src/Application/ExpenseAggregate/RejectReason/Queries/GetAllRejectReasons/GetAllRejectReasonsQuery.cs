using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.RejectReason.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.RejectReason.Queries.GetAllRejectReasons
{
    public class GetAllRejectReasonsQuery : IRequest<ICollection<RejectReasonDto>>
    {
    }
}
