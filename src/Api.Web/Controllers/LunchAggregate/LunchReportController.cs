using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Queries.GetAllLunchReportByStatus;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Queries.GetDocumentByLunchForm;
using System.Threading.Tasks;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Commands.PathLunchFormPaidStatus;

namespace Prome.Viaticos.Server.Api.Web.Controllers.LunchAggregate
{
    public class LunchReportController : ApiController
    {
        [HttpGet]
        [Route("GetByStatus/{StatusId}/{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByLunchForm(int statusId, string user)
        {
            var query = new GetAllLunchReportByStatusQuery { StatusId = statusId, Email = this.GetUserAuthorized(user) };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetPrintDocument/{Id}/{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDocumentAttached(int id, string user)
        {
            var query = new GetDocumentByLunchFormQuery { Id = id, Email = this.GetUserAuthorized(user) };
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

        [HttpPatch]
        [Route("StatusPaid/{expenseFormId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> StatusPaid(int expenseFormId, PathLunchFormPaidStatusCommand pathLunchFormPaidStatusCommand)
        {
            pathLunchFormPaidStatusCommand.Id = expenseFormId;
            await Mediator.Send(pathLunchFormPaidStatusCommand);
            return Ok();
        }
    }
}