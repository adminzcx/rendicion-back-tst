using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;
using System;

namespace Prome.Viaticos.Server.Domain.Entities.AdminAggregate
{
    public class ExpenseStops : BaseEntity
    {
        public virtual Reason Reason { get; set; }

        public virtual Concept Concept { get; set; }

        public DateTime ValidityStartDate { get; set; }

        public decimal? CapAmount { get; set; }

        public int TypeStop { get; set; }

        public bool IsDeleted { get; set; } = false;

    }
}
