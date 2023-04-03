using MediatR;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GetAllExpenseFormToManaging
{

    public class GetAllExpenseFormToManagingQuery : IRequest<ICollection<ExpenseFormListDto>>
    {
        public string Email { get; set; }

        public int ExpenseExternalAuth { get; set; }

    }
}
