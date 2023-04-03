using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications
{
    public class ByEmployeeCuitSpecification : BaseSpecification<User>
    {
        public ByEmployeeCuitSpecification(string cuit)
            : base(x => x.Cuit.Trim().TrimEnd().Equals(cuit))
        {
        }
    }
}