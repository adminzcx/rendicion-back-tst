using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Commands.CreateLunchStops;
using Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Commands.DeleteLunchStops;
using Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Commands.UpdateLunchStops;
using Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Queries.GetAllLunchStops;
using Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Queries.GetLunchStop;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.AdminAggregate
{
    public class LunchStopsController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllLunchStopsQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetLunchStop")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var query = new GetLunchStopQuery { Id = id };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateLunchStopsCommand createLunchStopsCommand)
        {
            await Mediator.Send(createLunchStopsCommand);

            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdateLunchStopsCommand updateLunchStopsCommand)
        {
            updateLunchStopsCommand.Id = id;
            await Mediator.Send(updateLunchStopsCommand);

            return Ok();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteLunchStopsCommand = new DeleteLunchStopsCommand
            {
                Id = id
            };

            await Mediator.Send(deleteLunchStopsCommand);

            return Ok();
        }
    }
}
