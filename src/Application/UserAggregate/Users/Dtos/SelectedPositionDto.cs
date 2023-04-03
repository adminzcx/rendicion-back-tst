using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos
{

    public class SelectedPositionDto : IMapFrom<Position>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}
