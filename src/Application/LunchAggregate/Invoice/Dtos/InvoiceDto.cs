using Prome.Viaticos.Server.Application._Common.Mappings;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Invoice.Dtos
{
    public class InvoiceDto : IMapFrom<Domain.Entities.LunchAggregate.Invoice>
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
