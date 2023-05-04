using Ardalis.GuardClauses;
using Prome.Viaticos.Server.Domain.Entities.CuentaCorrienteAggregate;
using System;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Guards
{
    public static class CuentasCorrientesGuard
    {
        public static void IsValidLegajo(this IGuardClause guardClause, IReadOnlyCollection<CuentasCorrientes> input)
        {
            if (input.Count == 0)
                throw new ArgumentException("Legajo Inexistente.");
        }
    }
}
