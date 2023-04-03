using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Application.UserAggregate.Zones.Dtos
{
    public class ZoneDto : IMapFrom<Zone>
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
