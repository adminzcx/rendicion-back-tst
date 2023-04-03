using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Application.UserAggregate.SubZones.Dtos
{
    public class SubZoneDto : IMapFrom<SubZone>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int ZoneId { get; set; }
    }
}
