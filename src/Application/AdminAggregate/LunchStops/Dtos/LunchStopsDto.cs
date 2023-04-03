using Prome.Viaticos.Server.Application._Common.Mappings;
using System;

namespace Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Dtos
{
    public class LunchStopsDto : IMapFrom<Domain.Entities.AdminAggregate.LunchStops>
    {
        public long Id { get; set; }

        public DateTime ValidityStartDate { get; set; }

        public decimal CapAmount { get; set; }

        public bool IsMonthly { get; set; }
    }
}
