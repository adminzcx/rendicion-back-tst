using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Domain.Entities.CashFormAggregate
{
    public class CashFormMoney : BaseEntity
    {
        public virtual CashForm CashForm { get; set; }

        public virtual MoneyType MoneyType { get; set; }

        public virtual User User { get; set; }

        public decimal? Amount { get; set; }

        public decimal? Total { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}