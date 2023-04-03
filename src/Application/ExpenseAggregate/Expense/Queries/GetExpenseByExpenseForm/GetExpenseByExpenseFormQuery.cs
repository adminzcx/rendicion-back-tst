using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Queries.GetExpenseByExpenseForm
{

    public class GetExpenseByExpenseFormQuery : IRequest<ICollection<ExpenseListDto>>
    {
        public int ExpenseFormId { get; set; }
    }
}
