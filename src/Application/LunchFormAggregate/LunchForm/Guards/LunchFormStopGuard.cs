using Ardalis.GuardClauses;
using System;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Guards
{
    public static class LunchFormStopGuard
    {
        public static void LunchFormStopDailyGuardValid(this IGuardClause guardClause, decimal? input, decimal? tope)
        {
            if (tope == 0) return;
            if (input == 0) return;

            if (input > tope)
                throw new ArgumentException("Se está superando el tope permitido diario. Ingrese un valor menor para continuar la carga.");
        }

        public static void LunchFormStopMonthlyGuardValid(this IGuardClause guardClause, decimal? input, decimal? tope)
        {
            if (tope == 0) return;
            if (input == 0) return;

            if (input > tope)
                throw new ArgumentException("Se está superando el tope permitido mensual. Ingrese un valor menor para continuar la carga.");
        }
    }
}