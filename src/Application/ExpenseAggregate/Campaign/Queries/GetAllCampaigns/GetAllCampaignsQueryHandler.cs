using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Campaign.Dtos;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Campaign.Specifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Campaign.Queries.GetAllCampaigns
{
    public class GetAllCampaignsQueryHandler : QueryHandler<GetAllCampaignsQuery, ICollection<CampaignDto>>
    {
        public GetAllCampaignsQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<CampaignDto>> Handle(GetAllCampaignsQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.ExpenseAggregate.Campaign>()
                .ListAsync(new CampaignsEnabledSpecification());

            return Map(list);
        }
    }
}
