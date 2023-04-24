using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetAllCashFormReportByStatus;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetCashForm;
using System.Threading.Tasks;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Commands.PathCashFormPaidStatus;

namespace Prome.Viaticos.Server.Api.Web.Controllers.CashFormAggregate
{
    public class CashFormReportController : ApiController
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

        [HttpGet]
        [Route("GetByStatus/{StatusId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCashFormByStatus(int statusId)
        {
            var query = new GetAllCashFormReportByStatusQuery { StatusId = statusId, Email = this.GetUserAuthorized() };
            var result = await Mediator.Send(query);

            return Ok(result);
        }
        [HttpPatch]
        [Route("StatusPaid/{cashFormId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> StatusPaid(int cashFormId, PathCashFormPaidStatusCommand pathCashFormPaidStatusCommand)
        {
            pathCashFormPaidStatusCommand.Id = cashFormId;
            await Mediator.Send(pathCashFormPaidStatusCommand);
            return Ok();
        }
    }
}