using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Commands.CreateCashFormCapAmount;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Commands.DeleteCashFormAmount;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Commands.UpdateCashFormCapAmount;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Queries.GetAllCashFormCapAmount;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Queries.GetCashFormCapAmount;

namespace Prome.Viaticos.Server.Api.Web.Controllers.CashFormAggregate
{
    public class CashFormCapAmountController : ApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCashFormCapAmountQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateCashFormCapAmountCommand createCashFormCapAmount)
        {
            await Mediator.Send(createCashFormCapAmount);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteCashFormCapAmountCommand = new DeleteCashFormCapAmountCommand
            {
                Id = id
            };

            await Mediator.Send(deleteCashFormCapAmountCommand);

            return Ok();
        }

        [HttpGet("{id}", Name = "GetCashFormCapAmount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var query = new GetCashFormCapAmountQuery();
            query.Id = id;
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdateCashFormCapAmountCommand updateCashFormCapAmountCommand)
        {
            updateCashFormCapAmountCommand.Id = id;
            await Mediator.Send(updateCashFormCapAmountCommand);

            return Ok();
        }
    }
}
