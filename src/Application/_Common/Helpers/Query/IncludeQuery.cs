using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Application.Common.Helpers.Query;
using System.Collections.Generic;
using System.Linq;

namespace Prome.Viaticos.Server.Application._Common.Helpers.Query
{
    public class IncludeQuery<TEntity, TPreviousProperty>
        : IIncludeQuery<TEntity, TPreviousProperty>
    {
        public IDictionary<IIncludeQuery, string> PathMap { get; } = new Dictionary<IIncludeQuery, string>();

        public IncludeVisitor Visitor { get; } = new IncludeVisitor();

        public IncludeQuery(IDictionary<IIncludeQuery, string> pathMap)
        {
            PathMap = pathMap;
        }

        public HashSet<string> Paths => PathMap.Select(x => x.Value).ToHashSet();
    }
}
