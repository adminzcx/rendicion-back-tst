using MediatR;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchFormComment.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchFormComment.Queries.GetAllLunchFormCommentByFormId
{
    public class GetAllLunchFormCommentByFormIdQuery : IRequest<ICollection<LunchFormCommentListDto>>
    {
        public int Id { get; set; }
    }
}
