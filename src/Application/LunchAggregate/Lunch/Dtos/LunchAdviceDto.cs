using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.LunchAggregate;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Dtos
{

    public class LunchAdviceDto : IMapFrom<LunchAdvice>
    {

        public string Title { get; set; }

        public string Description { get; set; }

    }
}
