using Ardalis.GuardClauses;
using Prome.Viaticos.Server.Domain.Entities.DatosMillanAggregate;
using System;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.DatosMillanAggregate.Guards
{
    public static class DatosMillanGuard
    {
        public static void UniqueDatosMillan(this IGuardClause guardClause, IReadOnlyCollection<DatosMillan> input)
        {
            if (input.Count != 1)
                throw new ArgumentException("No se ha podido seleccionar 1 usuario único para ese legajo");
        }

        public static void IsValidDatosMillan(this IGuardClause guardClause, IReadOnlyCollection<DatosMillan> input)
        {
            if (input.Count == 0)
                throw new ArgumentException("Usuario Inexistente.");
        }

        public static void IsExistEmployeeRecord(this IGuardClause guardClause, IReadOnlyCollection<DatosMillan> input)
        {
            if (input.Count > 1)
                throw new ArgumentException("Ya existe un usuario para este legajo.");
        }

    }
}

