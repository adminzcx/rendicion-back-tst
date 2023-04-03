using MediatR;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using System;



namespace Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Commands.UpdateKmPriceConfiguration
{

    public class UpdateKmPriceConfigurationCommand : IRequest, IMapFrom<KmPriceConfiguration>
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public int ZoneId { get; set; }

        public int SubZoneId { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }
    }
}
