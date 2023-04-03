using Prome.Viaticos.Server.Application.Common.Helpers.Query;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application._Common.Interfaces
{
    public interface IIncludeQuery
    {
        IDictionary<IIncludeQuery, string> PathMap { get; }

        IncludeVisitor Visitor { get; }

        HashSet<string> Paths { get; }
    }

    public interface IIncludeQuery<TEntity, out TPreviousProperty> : IIncludeQuery
    {
    }
}
