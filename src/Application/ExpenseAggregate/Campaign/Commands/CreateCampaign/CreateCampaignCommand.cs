using MediatR;
using Prome.Viaticos.Server.Application._Common.Mappings;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Campaign.Commands.CreateCampaign
{
    public class CreateCampaignCommand : IRequest, IMapFrom<Domain.Entities.ExpenseAggregate.Campaign>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
