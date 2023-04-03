using Prome.Viaticos.Server.Domain._Common;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate
{
    public class Reason : BaseNameEntity
    {
        public Reason(string name)
            : base(name)
        { }

        public virtual IList<Concept> Concepts { get; set; }
    }
}