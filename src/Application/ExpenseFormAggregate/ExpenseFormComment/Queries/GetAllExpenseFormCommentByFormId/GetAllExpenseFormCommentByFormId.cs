using MediatR;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseFormComment.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseFormComment.Queries.GetAllExpenseFormCommentByFormId
{


    public class GetAllExpenseFormCommentByFormId : IRequest<ICollection<ExpenseFormCommentListDto>>
    {
        public int Id { get; set; }
    }
}
