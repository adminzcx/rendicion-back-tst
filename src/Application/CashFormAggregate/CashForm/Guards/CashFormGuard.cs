using Ardalis.GuardClauses;
using Prome.Viaticos.Server.Domain.Entities.LunchAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Guards
{
    public static class CashFormGuard
    {
        public static void CashToRenderValid(this IGuardClause guardClause, IReadOnlyCollection<Lunch> input)
        {
            if (!input.Any())
                throw new ArgumentException("No existe rendición de caja pendientes de presentar.");
        }
    }
}