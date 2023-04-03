using System;
using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Specifications
{
    public class CashFormCapAmountSpecification : BaseSpecification<Domain.Entities.CashFormAggregate.CashFormCapAmount>
    {
        public CashFormCapAmountSpecification()
            : base(x => x.IsDeleted != true)
        {
        }
    }
}
