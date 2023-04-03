using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications
{
    public class ByEmployeeBranchSpecification : BaseSpecification<User>
    {
        public ByEmployeeBranchSpecification(long branchId)
            : base(x => x.Branch.Id == branchId)
        {
        }
    }
}
