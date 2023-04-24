using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormComment.Commands.CreateCashFormComment;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormComment.Queries.GetAllCashFormCommentByFormId;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.CashFormAggregate
{
    public class CashFormCommentsController : ApiController
    {
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var query = new GetAllCashFormCommentByFormIdQuery { Id = id };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateCashFormCommentCommand createCashFormCommentCommand)
        {
            createCashFormCommentCommand.Email = this.GetUserAuthorized();
            await Mediator.Send(createCashFormCommentCommand);

            return Ok();
        }
    }
}
