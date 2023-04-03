using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Campaign.Commands.CreateCampaign;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Campaign.Commands.DeleteCampaign;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Campaign.Commands.UpdateCampaign;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Campaign.Queries.GetAllCampaigns;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.ExpenseAggregate
{

    public class CampaignsController : ApiController
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCampaignsQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateCampaignCommand createCampaignCommand)
        {
            //createExpenseCommand.Email = this.GetUserAuthorized();
            await Mediator.Send(createCampaignCommand);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteCampaignCommand = new DeleteCampaignCommand
            {
                Id = id
            };

            await Mediator.Send(deleteCampaignCommand);

            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdateCampaignCommand updateCampaignCommand)
        {
            updateCampaignCommand.Id = id;
            await Mediator.Send(updateCampaignCommand);

            return Ok();
        }
    }
}
