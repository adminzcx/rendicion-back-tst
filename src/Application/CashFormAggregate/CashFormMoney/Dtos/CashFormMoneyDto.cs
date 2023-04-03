using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Application.CashFormAggregate.MoneyType.Dtos;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormMoney.Dtos
{
    public class CashFormMoneyDto : IMapFrom<Domain.Entities.CashFormAggregate.CashFormMoney>
    {
        public long Id { get; set; }

        public MoneyTypeDto MoneyType { get; set; }

        public decimal Amount { get; set; }

        public decimal Total { get; set; }

    }
}