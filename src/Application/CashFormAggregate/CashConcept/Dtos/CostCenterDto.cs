using Prome.Viaticos.Server.Application._Common.Mappings;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashConcept.Dtos
{
    public class CostCenterDto : IMapFrom<Domain.Entities.CashFormAggregate.CostCenter>
    {
        public long Id { get; set; }

        public string Name { get; set; }


    }
}
