

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Reason.Queries.GetAllReasons;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Reason.Queries.GetAllReasonsByPosition;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.ExpenseAggregate
{
    public class ReasonsController : ApiController
    {

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllReasonsQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByPosition()
        {
            var query = new GetAllReasonsByPositionQuery
            {
                Email = this.GetUserAuthorized()
            };
            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
