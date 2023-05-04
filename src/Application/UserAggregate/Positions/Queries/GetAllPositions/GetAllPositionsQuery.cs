using MediatR;
using Prome.Viaticos.Server.Application.UserAggregate.Positions.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.UserAggregate.Positions.Queries.GetAllPositions
{
    public class GetAllPositionsQuery : IRequest<ICollection<PositionDto>>
    {
    }
}
