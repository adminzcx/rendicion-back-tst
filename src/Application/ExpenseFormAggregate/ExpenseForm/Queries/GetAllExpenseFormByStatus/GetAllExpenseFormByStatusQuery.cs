using MediatR;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GetAllExpenseFormByStatus
{

    public class GetAllExpenseFormByStatusQuery : IRequest<ICollection<ExpenseFormListDto>>
    {
        public string Email { get; set; }
        public int StatusId { get; set; }

    }
}
