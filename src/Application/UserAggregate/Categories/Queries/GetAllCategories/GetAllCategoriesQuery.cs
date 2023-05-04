using MediatR;
using Prome.Viaticos.Server.Application.UserAggregate.Categories.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.UserAggregate.Categories.Queries.GetAllCategories
{

    public class GetAllCategoriesQuery : IRequest<ICollection<CategoryDto>>
    {
    }
}
