
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Dtos;
using Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Queries.GetAllKmPriceConfigurations
{

    public class GetAllKmPriceConfigurationsQueryHandler : QueryHandler<GetAllKmPriceConfigurationsQuery, ICollection<KmPriceConfigurationListDto>>
    {
        public GetAllKmPriceConfigurationsQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<KmPriceConfigurationListDto>> Handle(GetAllKmPriceConfigurationsQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<KmPriceConfiguration>()
                .ListAsync(new KmPriceConfigurationByTypeSpecification(request.KmPriceTypeId));

            return Map(list);
        }
    }
}
