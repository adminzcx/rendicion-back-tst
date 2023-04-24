using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Commands.CreateExpense;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Commands.DeleteExpense;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Commands.PatchExpense;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Commands.UpdateExpense;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Queries.GetAllPendingExpenses;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Queries.GetDocumentByExpense;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Queries.GetExpense;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Queries.GetExpenseByExpenseForm;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Queries.GetMapByExpense;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.ExpenseAggregate
{


    public class ExpensesController : ApiController
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllPendingExpensesQuery { Email = this.GetUserAuthorized() };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var query = new GetExpenseQuery { Id = id };
            var result = await Mediator.Send(query);

            return Ok(result);
        }


        [HttpPost]
        [Route("Create")]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateExpenseCommand createExpenseCommand)
        {
            createExpenseCommand.Email = this.GetUserAuthorized();
            await Mediator.Send(createExpenseCommand);

            return Ok();
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdateExpenseCommand updateExpenseCommand)
        {
            updateExpenseCommand.Id = id;
            await Mediator.Send(updateExpenseCommand);

            return Ok();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteExpenseCommand = new DeleteExpenseCommand
            {
                Id = id
            };

            await Mediator.Send(deleteExpenseCommand);

            return Ok();
        }

        [HttpPatch("{expenseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Patch(int expenseId, PatchExpenseCommand patchExpenseCommand)
        {
            patchExpenseCommand.Id = expenseId;
            patchExpenseCommand.Email = this.GetUserAuthorized();
            await Mediator.Send(patchExpenseCommand);

            return Ok();
        }

        [HttpGet]
        [Route("GetDocumentAttached/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDocumentAttached(int id)
        {
            var query = new GetDocumentByExpenseQuery { Id = id };
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

        [HttpGet]
        [Route("GetGoogleMapImage/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGoogleMapImage(int id)
        {
            var query = new GetMapByExpenseQuery { Id = id };
            var result = await Mediator.Send(query);

            System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
            {
                FileName = result.FileName,
                Inline = false
            };
            Response.Headers.Add("Content-Disposition", cd.ToString());
            Response.Headers.Add("X-Content-Type-Options", "nosniff");
            return File(result.DocumentAttached, result.Mime);
        }

        [HttpGet]
        [Route("GetByExpenseForm/{ExpenseFormId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByExpenseForm(int expenseFormId)
        {
            var query = new GetExpenseByExpenseFormQuery { ExpenseFormId = expenseFormId };
            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
