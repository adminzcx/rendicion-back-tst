using Prome.Viaticos.Server.Application._Common.Mappings;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Branch.Dtos
{
    public class BranchDto : IMapFrom<Domain.Entities.UserAggregate.Branch>
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int SubZoneId { get; set; }
    }
}
