using System;
using Ardalis.GuardClauses;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Guards
{
    public static class CashFormStopGuard
    {
        public static void CashFormStopGuardValid(this IGuardClause guardClause, decimal? input, decimal? tope)
        {
            if (tope == 0) return;
            if (input == 0) return;

            if (input > tope)
                throw new ArgumentException("Se está superando el tope permitido. Ingrese un valor menor para continuar la carga.");
        }
    }
}
