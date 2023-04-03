
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Segment.Queries.GetAllSegments;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.ExpenseAggregate
{


    public class SegmentsController : ApiController
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllSegmentsQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

    }
}
