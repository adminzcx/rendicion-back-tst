using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.CreateExpenseForm;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.PathExpenseForm;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.PathExpenseFormAdvices;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.PathExpenseFormAmount;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.PathExpenseFormPaidStatus;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.PathExpenseFormStatus;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GeCashFormToCalipso;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GetAllExpenseForm;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GetAllExpenseFormByStatus;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GetAllExpenseFormToManaging;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GetDashboardExpenseForm;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GetDocumentByExpenseForm;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GetExpenseForm;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GetExpensesByDate;
using System;
using System.Threading.Tasks;


namespace Prome.Viaticos.Server.Api.Web.Controllers.ExpenseFormAggregate
{

    public class ExpenseFormsController : ApiController
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllExpenseFormQuery
            {
                Email = this.GetUserAuthorized()
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
            var query = new GetExpenseFormQuery { Id = id };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetByStatus/{StatusId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByExpenseForm(int statusId)
        {
            var query = new GetAllExpenseFormByStatusQuery { StatusId = statusId, Email = this.GetUserAuthorized() };
            var result = await Mediator.Send(query);

            return Ok(result);
        }


        [HttpGet]
        [Route("GetPendingToManage/{ExpenseExternalAuth}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPendingToManage(int expenseExternalAuth)
        {
            var query = new GetAllExpenseFormToManagingQuery
            {
                ExpenseExternalAuth = expenseExternalAuth,
                Email = this.GetUserAuthorized()
            };
            var result = await Mediator.Send(query);

            return Ok(result);
        }


        [HttpPost]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateExpenseFormCommand createExpenseFormCommand)
        {
            createExpenseFormCommand.Email = this.GetUserAuthorized();
            await Mediator.Send(createExpenseFormCommand);

            return Ok();
        }

        [HttpPatch("{expenseFormId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Patch(int expenseFormId, PathExpenseFormCommand pathExpenseFormCommand)
        {
            pathExpenseFormCommand.Id = expenseFormId;
            pathExpenseFormCommand.Email = this.GetUserAuthorized();
            await Mediator.Send(pathExpenseFormCommand);

            return Ok();
        }

        [HttpPatch]
        [Route("Status/{expenseFormId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchStatus(int expenseFormId, PathExpenseFormStatusCommand pathExpenseFormStatusCommand)
        {
            pathExpenseFormStatusCommand.Id = expenseFormId;
            pathExpenseFormStatusCommand.Email = this.GetUserAuthorized();
            await Mediator.Send(pathExpenseFormStatusCommand);

            return Ok();
        }

        [HttpPatch]
        [Route("StatusPaid/{expenseFormId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> StatusPaid(int expenseFormId, PathExpenseFormPaidStatusCommand pathExpenseFormPaidStatusCommand)
        {
            pathExpenseFormPaidStatusCommand.Id = expenseFormId;
            await Mediator.Send(pathExpenseFormPaidStatusCommand);
            return Ok();
        }

        [HttpPatch("Amount/{expenseFormId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchAmount(int expenseFormId, PathExpenseFormAmountCommand pathExpenseFormAmountCommand)
        {
            pathExpenseFormAmountCommand.Id = expenseFormId;
            pathExpenseFormAmountCommand.Email = this.GetUserAuthorized();
            await Mediator.Send(pathExpenseFormAmountCommand);

            return Ok();
        }

        [HttpPatch]
        [Route("Advices/{cashFormId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchAdvices(int cashFormId, PathExpenseFormAdvicesCommand pathExpenseFormAdvicesCommand)
        {
            pathExpenseFormAdvicesCommand.Id = cashFormId;
            pathExpenseFormAdvicesCommand.Email = this.GetUserAuthorized();
            await Mediator.Send(pathExpenseFormAdvicesCommand);

            return Ok();
        }

        [HttpGet]
        [Route("GetPrintDocument/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDocumentAttached(int id)
        {
            var query = new GetDocumentByExpenseFormQuery { Id = id };
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
        [Route("GetDashboard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDashboard()
        {
            var query = new GetDashboardExpenseFormQuery
            {
                Email = this.GetUserAuthorized()
            };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetByDate/{startDate}/{endDate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByDateAsync(DateTime startDate, DateTime endDate)
        {
            var query = new GetExpenseFormByDateQuery
            {
                StartDate = startDate,
                EndDate = endDate
            };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetCalipsoDocument/{startDate}/{endDate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCalipsoDocument(DateTime startDate, DateTime endDate)
        {
            var query = new GeCashFormToCalipsoQuery
            {
                StartDate = startDate,
                EndDate = endDate
            };
            var result = await Mediator.Send(query);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = result.FileName,
                Inline = false
            };
            Response.Headers.Add("Content-Disposition", cd.ToString());
            Response.Headers.Add("X-Content-Type-Options", "nosniff");
            return File(result.DocumentAttached, result.Mime);
        }
    }
}
