using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Commands.CreateLunch;
using Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Commands.DeleteLunch;
using Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Commands.UpdateLunch;
using Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Queries;
using Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Queries.GetByLunchForm;
using Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Queries.GetLunch;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Commands.ImportExcelFile;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Queries.GetDashboardLunchForm;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.LunchAggregate
{
    public class LunchController : ApiController
    {

        [HttpPost]
        [Route("Create")]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateLunchCommand createLunchCommand)
        {
            createLunchCommand.Email = this.GetUserAuthorized();
            await Mediator.Send(createLunchCommand);
            return Ok();
        }

        [HttpPost]
        [Route("ImportFiles")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ImportFiles(ImportExcelFileCommand importExcelFileCommand)
        {
            await Mediator.Send(importExcelFileCommand);
            return Ok();
        }

        [HttpGet]
        [Route("GetLunchDashboard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDashboard()
        {
            var query = new GetDashboardLunchFormQuery
            {
                Email = this.GetUserAuthorized()
            };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetByUserQuery
            {
                Email = this.GetUserAuthorized()
            };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetByLunchForm/{LunchFormId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByLunchForm(int lunchFormId)
        {
            var query = new GetByLunchFormQuery
            {
                Email = this.GetUserAuthorized(),
                LunchFormId = lunchFormId
            };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteLunchCommand = new DeleteLunchCommand { Id = id };
            await Mediator.Send(deleteLunchCommand);
            return Ok();
        }

        [HttpGet()]
        [Route("GetByIdAsync/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetLunchQuery { Id = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdateLunchCommand updateLunchCommand)
        {
            updateLunchCommand.Id = id;
            await Mediator.Send(updateLunchCommand);
            return Ok();
        }
    }
}
