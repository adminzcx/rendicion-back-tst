using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;

namespace Prome.Viaticos.Server.Domain.Entities.CashFormAggregate
{
    public class CashFormExpense : BaseEntity
    {
        public int Number { get; set; }

        public DateTime Date { get; set; }

        public virtual CashForm CashForm { get; set; }

        public virtual User User { get; set; }

        public string Vendor { get; set; }

        public virtual CashConcept CashConcept { get; set; }

        public virtual CostCenter CostCenter { get; set; }

        public decimal Total { get; set; }

        public string DocumentAttached { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}