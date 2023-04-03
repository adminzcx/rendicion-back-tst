using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;

namespace Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Specifications
{
    public class UserSubstitutionByUserSpecification : BaseSpecification<UserSubstitution>
    {
        public UserSubstitutionByUserSpecification(long userId)
            : base(x => x.ReplaceByUser.Id == userId && x.IsDeleted != true)
        {
            Includes.Add(x => x.User);
        }
    }
}
