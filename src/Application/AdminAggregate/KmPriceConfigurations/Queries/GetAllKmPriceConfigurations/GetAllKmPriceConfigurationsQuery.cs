using MediatR;
using Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Queries.GetAllKmPriceConfigurations
{
    public class GetAllKmPriceConfigurationsQuery : IRequest<ICollection<KmPriceConfigurationListDto>>
    {
        public int KmPriceTypeId { get; set; }

    }
}
