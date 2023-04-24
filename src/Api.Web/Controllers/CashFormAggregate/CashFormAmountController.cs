using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Commands.CreateCashFormAmount;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Commands.DeleteCashFormAmount;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Commands.UpdateCashFormAmount;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Queries.GetAllCashFormAmount;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Queries.GetCashFormAmount;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Queries.GetCashFormAmountByBranch;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.CashFormAggregate
{
    public class CashFormAmountController : ApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCashFormAmountQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateCashFormAmountCommand createCashFormAmount)
        {
            await Mediator.Send(createCashFormAmount);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteCashFormAmountCommand = new DeleteCashFormAmountCommand
            {
                Id = id
            };

            await Mediator.Send(deleteCashFormAmountCommand);

            return Ok();
        }

        [HttpGet("{id}", Name = "GetCashFormAmount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var query = new GetCashFormAmountQuery();
            query.Id = id;
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdateCashFormAmountCommand updateCashFormAmountCommand)
        {
            updateCashFormAmountCommand.Id = id;
            await Mediator.Send(updateCashFormAmountCommand);

            return Ok();
        }
        [HttpGet]
        [Route("GetByBranch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByBranch()
        {
            var query = new GetCashFormAmountByBranchQuery
            {
                Email = this.GetUserAuthorized()
            };
            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
