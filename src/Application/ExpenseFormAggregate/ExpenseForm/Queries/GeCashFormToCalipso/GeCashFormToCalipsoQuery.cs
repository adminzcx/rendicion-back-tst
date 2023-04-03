using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;
using System;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GeCashFormToCalipso
{

    public class GeCashFormToCalipsoQuery : IRequest<DocumentAttachedDto>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
