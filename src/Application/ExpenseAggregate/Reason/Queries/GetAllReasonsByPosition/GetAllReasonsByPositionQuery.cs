using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Reason.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Reason.Queries.GetAllReasonsByPosition
{
    public class GetAllReasonsByPositionQuery : IRequest<ICollection<ReasontDto>>
    {
        public string Email { get; set; }
    }
}
