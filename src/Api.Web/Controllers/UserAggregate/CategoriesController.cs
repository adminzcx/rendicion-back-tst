using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.UserAggregate.Categories.Queries.GetAllCategories;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.UserAggregate
{

    public class CategoriesController : ApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCategoriesQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
