using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchFormComment.Commands.CreateLunchFormComment;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchFormComment.Queries.GetAllLunchFormCommentByFormId;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.LunchFormAggregate
{
    public class LunchFormCommentsController : ApiController
    {
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var query = new GetAllLunchFormCommentByFormIdQuery { Id = id };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("Create/{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(string user, CreateLunchFormCommentCommand createLunchFormCommentCommand)
        {
            createLunchFormCommentCommand.Email = this.GetUserAuthorized(user);
            await Mediator.Send(createLunchFormCommentCommand);

            return Ok();
        }
    }
}
