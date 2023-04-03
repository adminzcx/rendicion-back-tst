
using MediatR;
using Prome.Viaticos.Server.Domain.Enums;
using System;

namespace Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Commands.CreateKmPriceConfiguration
{


    public class CreateKmPriceConfigurationCommand : IRequest
    {
        public long UserId { get; set; }

        public int ZoneId { get; set; }

        public int SubZoneId { get; set; }

        public decimal Price { get; set; }

        public DateTime? StartDate { get; set; }

        public KmPriceTypeEnum KmPriceType { get; set; }
    }
}
