using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Commands.CreateCashForm;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Commands.PathCashFormStatus;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Commands.UpdateCashForm;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetCalipsoByCashForm;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetCashForm;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetCashFormByDate;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetCashFormPending;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetDashboardCashForm;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetDocumentByCashForm;
using System;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.CashFormAggregate
{
    public class CashFormController : ApiController
    {

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var query = new GetCashFormQuery { Id = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route("{user}")]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(string user, CreateCashFormCommand createCashFormCommand)
        {
            createCashFormCommand.Email = this.GetUserAuthorized(user);
            await Mediator.Send(createCashFormCommand);
            return Ok();
        }

        [HttpPatch]
        [Route("Status/{cashFormId}/{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchStatus(int cashFormId, string user, PathCashFormStatusCommand pathCashFormStatusCommand)
        {
            pathCashFormStatusCommand.Id = cashFormId;
            pathCashFormStatusCommand.Email = this.GetUserAuthorized(user);
            await Mediator.Send(pathCashFormStatusCommand);

            return Ok();
        }



        [HttpGet]
        [AllowAnonymous]
        [Route("GetByStatus/{StatusId}/{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCashFormByStatus(int statusId, string user)
        {
            var query = new GetCashFormPendingQuery { StatusId = statusId, Email = this.GetUserAuthorized(user) };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPut("{id}/{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, string user, UpdateCashFormCommand updateCashFormCommand)
        {
            updateCashFormCommand.Id = id;
            updateCashFormCommand.Email = this.GetUserAuthorized(user);
            await Mediator.Send(updateCashFormCommand);

            return Ok();
        }

        [HttpGet]
        [Route("GetPrintDocument/{Id}/{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDocumentAttached(int id, string user)
        {
            var query = new GetDocumentByCashFormQuery { Id = id, Email = this.GetUserAuthorized(user) };
            var result = await Mediator.Send(query);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = result.FileName,
                Inline = true
            };
            Response.Headers.Add("Content-Disposition", cd.ToString());
            Response.Headers.Add("X-Content-Type-Options", "nosniff");
            return File(result.DocumentAttached, result.Mime);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetCalipsoDocument/{Id}/{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCalipsoDocument(int id, string user)
        {
            var query = new GetCalipsoByCashFormQuery { Id = id, Email = this.GetUserAuthorized(user) };
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

        [HttpGet]
        [Route("GetCashDashboard/{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDashboard(string user)
        {
            var query = new GetDashboardCashFormQuery
            {
                Email = this.GetUserAuthorized(user)
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
            var query = new GetCashFormByDateQuery
            {
                StartDate = startDate,
                EndDate = endDate
            };
            var result = await Mediator.Send(query);

            return Ok(result);
        }


    }
}
