using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Application.UserAggregate.Positions.Dtos
{
    public class PositionDto : IMapFrom<Position>
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
