

using Prome.Viaticos.Server.Application._Common.Mappings;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.TechnicalVisit.Dtos
{
    public class TechnicalVisitDto : IMapFrom<Domain.Entities.ExpenseAggregate.TechnicalVisit>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

    }
}
