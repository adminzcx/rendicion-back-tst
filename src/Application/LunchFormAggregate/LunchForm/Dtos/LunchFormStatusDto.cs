using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.LunchFormAggregate;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Dtos
{
    public class LunchFormStatusDto : IMapFrom<LunchFormStatus>
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
