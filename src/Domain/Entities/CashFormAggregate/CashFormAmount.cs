using System;
using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Domain.Entities.CashFormAggregate
{
    public class CashFormAmount : BaseEntity
    {
        protected CashFormAmount()
            :base()
        {
        }

        public virtual Branch Branch { get; set; }

        public decimal Amount { get; set; }

        public DateTime StartDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
