using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.CashFormAggregate;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Dtos
{
    public class CashFormStatusDto : IMapFrom<CashFormStatus>
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
