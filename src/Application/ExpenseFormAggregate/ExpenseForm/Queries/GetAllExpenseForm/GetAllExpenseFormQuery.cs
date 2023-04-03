using MediatR;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GetAllExpenseForm
{


    public class GetAllExpenseFormQuery : IRequest<ICollection<ExpenseFormListDto>>
    {
        public string Email { get; set; }
    }
}
