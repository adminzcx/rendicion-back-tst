using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using System;

namespace Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Dtos
{
    public class KmPriceConfigurationDto : IMapFrom<KmPriceConfiguration>
    {
        public long Id { get; set; }

        public string Price { get; set; }

        public DateTime StartDate { get; set; }

    }
}
