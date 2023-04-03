using Ardalis.GuardClauses;
using Prome.Viaticos.Server.Domain.Entities.LunchAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Guards
{
    public static class LunchFormGuard
    {
        public static void LunchToRenderValid(this IGuardClause guardClause, IReadOnlyCollection<Lunch> input)
        {
            if (!input.Any())
                throw new ArgumentException("No existen almuerzos pendientes de presentar.");
        }
    }
}