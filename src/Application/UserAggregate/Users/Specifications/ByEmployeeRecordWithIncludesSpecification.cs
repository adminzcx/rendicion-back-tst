namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications
{
    public sealed class ByEmployeeRecordWithIncludesSpecification : ByEmployeeRecordSpecification
    {
        public ByEmployeeRecordWithIncludesSpecification(string employeeRecord)
            : base(employeeRecord)
        {
            AddInclude(t => t.Position);
        }
    }
}
