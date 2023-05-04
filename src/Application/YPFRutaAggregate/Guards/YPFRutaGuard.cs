using Ardalis.GuardClauses;
using Prome.Viaticos.Server.Domain.Entities.YPFRutaAggregate;
using System;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.YPFRutaAggregate.Guards
{
    public static class YPFRutaGuard
    {
        public static void IsValidYPFRuta(this IGuardClause guardClause, IReadOnlyCollection<Datos_YPF> input)
        {
            if (input.Count == 0)
                throw new ArgumentException("Número de tarjeta inexistente.");
        }
    }
}
