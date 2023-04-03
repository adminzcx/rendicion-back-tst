
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Commands.CreateExpenseStops;
using Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Commands.DeleteExpenseStops;
using Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Commands.UpdateExpenseStops;
using Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Queries.GetAllExpenseStops;
using Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Queries.GetStops;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.AdminAggregate
{


    public class ExpenseStopsController : ApiController
    {


        [Route("GetByTypeStop/{TypeStopId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int typeStopId)
        {
            var query = new GetAllExpenseStopsQuery();
            query.TypeStopId = typeStopId;
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetStop")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var query = new GetStopsQuery { Id = id };
            var result = await Mediator.Send(query);

            return Ok(result);
        }


        [HttpPost]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateExpenseStopsCommand createStopsCommand)
        {
            await Mediator.Send(createStopsCommand);

            return Ok();
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdateExpenseStopsCommand updateExpenseStopsCommand)
        {
            updateExpenseStopsCommand.Id = id;
            await Mediator.Send(updateExpenseStopsCommand);

            return Ok();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteExpenseStopsCommand = new DeleteExpenseStopsCommand
            {
                Id = id
            };

            await Mediator.Send(deleteExpenseStopsCommand);

            return Ok();
        }
    }
}
