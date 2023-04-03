using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Domain.Entities.CashFormAggregate
{
    public class MoneyType : BaseNameEntity
    {
        public MoneyType(string name)
            : base(name)
        {
        }

        public decimal Value { get; set; }

        public bool IsCoin { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}