using Prome.Viaticos.Server.Application._Common.Mappings;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Campaign.Dtos
{
    public class CampaignDto : IMapFrom<Domain.Entities.ExpenseAggregate.Campaign>
    {
        public long Id { get; set; }

        public string Name { get; set; }

    }
}
