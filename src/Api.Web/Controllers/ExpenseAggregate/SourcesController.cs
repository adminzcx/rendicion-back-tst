
using Prome.Viaticos.Server.Application.ExpenseAggregate.Source.Queries.GetAllSources;

namespace Prome.Viaticos.Server.Api.Web.Controllers.ExpenseAggregate
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class SourcesController : ApiController
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllSourcesQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }


    }
}
