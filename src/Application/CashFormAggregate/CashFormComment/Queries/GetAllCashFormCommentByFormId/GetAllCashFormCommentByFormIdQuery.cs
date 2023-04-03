using MediatR;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormComment.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormComment.Queries.GetAllCashFormCommentByFormId
{
    public class GetAllCashFormCommentByFormIdQuery : IRequest<ICollection<CashFormCommentListDto>>
    {
        public int Id { get; set; }
    }
}