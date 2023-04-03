using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications
{
    public class ByEmployeeEmailSpecification : BaseSpecification<User>
    {
        public ByEmployeeEmailSpecification(string email)
            : base(x => x.Email.Equals(email))
        {
            Includes.Add(x => x.Position);
            Includes.Add(x => x.Management);
            Includes.Add(x => x.Sector);
            Includes.Add(x => x.Zone);
            Includes.Add(x => x.SubZone);
        }
    }
}
