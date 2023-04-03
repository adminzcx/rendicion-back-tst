using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Dtos;
using Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Queries.GetKmPriceConfiguration
{

    public class GetKmPriceConfigurationQueryHandler : QueryHandler<GetKmPriceConfigurationQuery, KmPriceConfigurationDto>
    {
        public GetKmPriceConfigurationQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<KmPriceConfigurationDto> Handle(GetKmPriceConfigurationQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<KmPriceConfiguration>()
                .SingleOrDefaultAsync(new KmPriceConfigurationByIdSpecification(request.Id));

            return Map(list);
        }
    }
}
