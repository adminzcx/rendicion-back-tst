using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications
{
    public class ByEmployeeRecordSpecification : BaseSpecification<User>
    {
        public ByEmployeeRecordSpecification(string employeeRecord)
            : base(x => x.EmployeeRecord.Trim().TrimEnd().Equals(employeeRecord))
        {
        }
    }
}
