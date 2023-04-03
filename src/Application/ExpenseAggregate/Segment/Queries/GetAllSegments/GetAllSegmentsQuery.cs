using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Segment.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Segment.Queries.GetAllSegments
{
    public class GetAllSegmentsQuery : IRequest<ICollection<SegmentDto>>
    {
    }
}
