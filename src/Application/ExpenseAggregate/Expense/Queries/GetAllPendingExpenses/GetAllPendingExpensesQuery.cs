using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Queries.GetAllPendingExpenses
{


    public class GetAllPendingExpensesQuery : IRequest<ICollection<ExpenseListDto>>
    {
        public string Email { get; set; }
    }
}
