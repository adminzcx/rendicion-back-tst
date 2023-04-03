using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Campaign.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Campaign.Queries.GetAllCampaigns
{
    public class GetAllCampaignsQuery : IRequest<ICollection<CampaignDto>>
    {
    }
}
