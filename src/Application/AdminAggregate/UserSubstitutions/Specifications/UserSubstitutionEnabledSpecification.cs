using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;

namespace Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Specifications
{


    public class UserSubstitutionEnabledSpecification : BaseSpecification<UserSubstitution>
    {
        public UserSubstitutionEnabledSpecification()
            : base(x => x.IsDeleted != true)
        {

        }
    }
}
