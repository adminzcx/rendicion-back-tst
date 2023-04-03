using Prome.Viaticos.Server.Application._Common.Mappings;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashConcept.Dtos
{
    public class CashConceptDto : IMapFrom<Domain.Entities.CashFormAggregate.CashConcept>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Calipso { get; set; }

        public CostCenterDto CostCenter { get; set; }
    }
}
