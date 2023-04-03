using Ardalis.GuardClauses;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Guards
{
    public static class UserGuard
    {
        public static void UniqueUser(this IGuardClause guardClause, IReadOnlyCollection<User> input)
        {
            if (input.Count != 1)
                throw new ArgumentException("No se ha podido seleccionar 1 usuario único para ese legajo");
        }

        public static void IsValidUser(this IGuardClause guardClause, IReadOnlyCollection<User> input)
        {
            if (input.Count == 0)
                throw new ArgumentException("Usuario Inexistente.");
        }

        public static void IsExistEmployeeRecord(this IGuardClause guardClause, IReadOnlyCollection<User> input)
        {
            if (input.Count > 1)
                throw new ArgumentException("Ya existe un usuario para este legajo.");
        }
    }
}