using Prome.Viaticos.Server.Application._Common.Mappings;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.Organism.Dtos
{
    public class OrganismDto : IMapFrom<Domain.Entities.CashFormAggregate.Organism>
    {
        public long Id { get; set; }

        public string Name { get; set; }


    }
}
