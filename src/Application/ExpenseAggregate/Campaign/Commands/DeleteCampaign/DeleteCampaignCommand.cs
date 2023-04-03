using MediatR;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Campaign.Commands.DeleteCampaign
{


    public class DeleteCampaignCommand : IRequest
    {
        public int Id { get; set; }
    }
}
