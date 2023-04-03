using MediatR;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using System;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GetExpensesByDate
{
    public class GetExpenseFormByDateQuery : IRequest<ICollection<ExpenseFormDto>>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}