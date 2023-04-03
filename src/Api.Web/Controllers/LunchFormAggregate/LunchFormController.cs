using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Commands.CreateLunchForm;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Commands.PatchLunchForm;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Commands.PathLunchFormStatus;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Queries.GetAllByStatusAndUser;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Queries.GetLunchForm;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.LunchFormAggregate
{
    public class LunchFormController : ApiController
    {

        [HttpPost]
        [Route("{user}")]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(string user, CreateLunchFormCommand createLunchFormCommand)
        {
            createLunchFormCommand.Email = this.GetUserAuthorized(user);
            await Mediator.Send(createLunchFormCommand);
            return Ok();
        }

        [HttpPut("{lunchFormId}/{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Patch(int lunchFormId, string user, PatchLunchFormCommand pathLunchFormCommand)
        {
            pathLunchFormCommand.Id = lunchFormId;
            pathLunchFormCommand.Email = this.GetUserAuthorized(user);
            await Mediator.Send(pathLunchFormCommand);
            return Ok();
        }

        [HttpGet]
        [Route("GetByStatus/{StatusId}/{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByStatus(int statusId, string user)
        {
            var query = new GetAllByStatusAndUserQuery
            {
                StatusId = statusId
                ,
                Email = this.GetUserAuthorized(user)
            };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var query = new GetLunchFormQuery { Id = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPatch]
        [Route("Status/{lunchFormId}/{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchStatus(int lunchFormId, string user, PathLunchFormStatusCommand pathLunchFormStatusCommand)
        {
            pathLunchFormStatusCommand.Id = lunchFormId;
            pathLunchFormStatusCommand.Email = this.GetUserAuthorized(user);
            await Mediator.Send(pathLunchFormStatusCommand);

            return Ok();
        }


    }
}
