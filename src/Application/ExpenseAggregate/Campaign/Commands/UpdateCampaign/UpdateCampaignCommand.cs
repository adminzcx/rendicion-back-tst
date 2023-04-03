using MediatR;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Campaign.Commands.UpdateCampaign
{
    public class UpdateCampaignCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
