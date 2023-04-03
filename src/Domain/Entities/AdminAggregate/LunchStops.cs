using Prome.Viaticos.Server.Domain._Common;
using System;

namespace Prome.Viaticos.Server.Domain.Entities.AdminAggregate
{
    public class LunchStops : BaseEntity
    {
        public LunchStops()
        {

        }

        public LunchStops(decimal capAmount, DateTime startDate, bool isMonthly)
        {
            this.CapAmount = capAmount;
            this.ValidityStartDate = startDate;
            this.IsMonthly = isMonthly;
        }

        public DateTime ValidityStartDate { get; set; }

        public decimal CapAmount { get; set; }

        public bool IsMonthly { get; set; } = false;

        public bool IsDeleted { get; set; } = false;
    }
}
