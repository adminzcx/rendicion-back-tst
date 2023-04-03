using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.MoneyType.Specifications
{
    public sealed class MoneyTypesSpecification : BaseSpecification<Domain.Entities.CashFormAggregate.MoneyType>
    {
        public MoneyTypesSpecification()
            : base(x=> x.IsDeleted==false)
        {

            ApplyOrderByDescending(x => x.Value);
        }
    }
}
