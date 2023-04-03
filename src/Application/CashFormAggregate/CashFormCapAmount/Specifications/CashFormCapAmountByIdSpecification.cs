using System;
using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Specifications
{
    public class CashFormCapAmountByIdSpecification : BaseSpecification<Domain.Entities.CashFormAggregate.CashFormCapAmount>
    {
        public CashFormCapAmountByIdSpecification(long id)
            : base(x => x.Id == id)
        {
            
        }
    }
}
