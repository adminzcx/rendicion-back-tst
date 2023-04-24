using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Commands.CreateCashFormExpense;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Commands.DeleteCashFormExpense;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Commands.UpdateCashFormExpense;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Queries.GetByCashForm;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Queries.GetDocumentByCashFormExpense;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.CashFormAggregate
{
    public class CashFormExpenseController : ApiController
    {

        [HttpPost]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateCashFormExpenseCommand createCashFormExpenseCommand)
        {
            createCashFormExpenseCommand.Email = this.GetUserAuthorized();
            await Mediator.Send(createCashFormExpenseCommand);
            return Ok();
        }
        [Route("GetByCashFormId/{cashFormId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int cashFormId)
        {
            var query = new GetCashFormExpenseByCashFormIdQuery { CashFormId = cashFormId, Email = this.GetUserAuthorized() };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteECashFormExpenseCommand = new DeleteECashFormExpenseCommand { Id = id };
            await Mediator.Send(deleteECashFormExpenseCommand);

            return Ok();
        }

        [HttpPut("{id}")]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdateCashFormExpenseCommand updateCashFormExpenseCommand)
        {
            updateCashFormExpenseCommand.Id = id;
            await Mediator.Send(updateCashFormExpenseCommand);

            return Ok();
        }

        [HttpGet]
        [Route("GetDocumentAttached/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDocumentAttached(int id)
        {
            var query = new GetDocumentByCashFormExpenseQuery { Id = id };
            var result = await Mediator.Send(query);

            System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
            {
                FileName = result.FileName,
                Inline = true
            };
            Response.Headers.Add("Content-Disposition", cd.ToString());
            Response.Headers.Add("X-Content-Type-Options", "nosniff");
            return File(result.DocumentAttached, result.Mime);
        }
    }
}
