using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications
{
    public class ByEmployeeDisabledDateSpecification : BaseSpecification<User>
    {
        public ByEmployeeDisabledDateSpecification(DateTime date)
            : base(x => x.DisabledDate == null || x.DisabledDate == date)
        {

        }
    }
}
