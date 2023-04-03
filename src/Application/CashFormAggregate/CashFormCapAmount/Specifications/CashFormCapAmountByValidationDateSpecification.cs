using System;
using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Specifications
{
    public class CashFormCapAmountByValidationDateSpecification :
        BaseSpecification<Domain.Entities.CashFormAggregate.CashFormCapAmount>
    {
        public CashFormCapAmountByValidationDateSpecification(DateTime date) :
        base(x => x.IsDeleted != true && x.Date <= date)
        {
            ApplyOrderByDescending(x => x.Date);
        }
    }
}
