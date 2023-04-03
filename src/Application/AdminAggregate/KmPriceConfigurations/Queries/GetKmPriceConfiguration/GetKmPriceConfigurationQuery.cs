using MediatR;
using Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Dtos;

namespace Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Queries.GetKmPriceConfiguration
{

    public class GetKmPriceConfigurationQuery : IRequest<KmPriceConfigurationDto>
    {
        public int Id { get; set; }
    }
}
