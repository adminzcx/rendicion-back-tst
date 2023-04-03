using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications
{
    public class ByEmployeePositionSpecification : BaseSpecification<User>
    {
        public ByEmployeePositionSpecification(string position, long? subZoneId = null, long? zoneId = null, long? sectorId = null)
            : base(x => x.Position.Code.Equals(position)
                   && (zoneId == null || x.Zone.Id == zoneId)
                   && (subZoneId == null || x.SubZone.Id == subZoneId)
                   && (sectorId == null || x.Sector.Id == sectorId)
            )
        {
            Includes.Add(x => x.Position);

        }
    }
}
