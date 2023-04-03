using System;
using Prome.Viaticos.Server.Application._Common.Mappings;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Dtos
{
    public class CashFormCapAmountDto : IMapFrom<Domain.Entities.CashFormAggregate.CashFormCapAmount>
    {
        public long Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
