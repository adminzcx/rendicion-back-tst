using Ardalis.GuardClauses;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Guards
{

    public static class ExpenseFormGuard
    {

        public static void ExpenseToRenderValid(this IGuardClause guardClause, IReadOnlyCollection<Expense> input)
        {
            if (!input.Any())
                throw new ArgumentException("No existe gastos pendientes de presentar.");
        }


    }
}