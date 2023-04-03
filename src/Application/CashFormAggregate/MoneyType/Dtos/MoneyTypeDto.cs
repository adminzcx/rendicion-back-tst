using Prome.Viaticos.Server.Application._Common.Mappings;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.MoneyType.Dtos
{
    public class MoneyTypeDto : IMapFrom<Domain.Entities.CashFormAggregate.MoneyType>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public bool IsCoin { get; set; }

    }
}
