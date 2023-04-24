using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Application.UserAggregate.Categories.Dtos
{


    public class CategoryDto : IMapFrom<Category>
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
