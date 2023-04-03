

using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Reason.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Reason.Queries.GetAllReasons
{
    public class GetAllReasonsQuery : IRequest<ICollection<ReasontDto>>
    {
    }
}
