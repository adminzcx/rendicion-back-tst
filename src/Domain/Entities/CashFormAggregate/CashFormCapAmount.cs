using System;
using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Domain.Entities.CashFormAggregate
{
    public class CashFormCapAmount : BaseEntity
    {
        protected CashFormCapAmount()
            :base()
        {
        }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
