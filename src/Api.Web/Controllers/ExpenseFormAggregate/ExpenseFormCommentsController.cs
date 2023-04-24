using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseFormComment.Commands.CreateExpenseFormComment;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseFormComment.Queries.GetAllExpenseFormCommentByFormId;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.ExpenseFormAggregate
{
    public class ExpenseFormCommentsController : ApiController
    {


        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var query = new GetAllExpenseFormCommentByFormId { Id = id };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateExpenseFormCommentCommand createExpenseFormCommentCommand)
        {
            createExpenseFormCommentCommand.Email = this.GetUserAuthorized();
            await Mediator.Send(createExpenseFormCommentCommand);

            return Ok();
        }
    }
}
