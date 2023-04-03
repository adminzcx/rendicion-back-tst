using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Categories.Dtos;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.UserAggregate.Categories.Queries.GetAllCategories
{

    public class GetAllCategoriesHandler : QueryHandler<GetAllCategoriesQuery, ICollection<CategoryDto>>
    {
        public GetAllCategoriesHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {

            var list = await _unitOfWork
             .Repository<Category>()
             .ListAllAsync();


            return Map(list);
        }
    }
}
