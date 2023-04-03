using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Commands.CreateKmPriceConfiguration;
using Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Commands.DeleteKmPriceConfiguration;
using Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Commands.UpdateKmPriceConfiguration;
using Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Queries.GetAllKmPriceConfigurations;
using Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Queries.GetKmPriceConfiguration;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.AdminAggregate
{

    public class KmPriceConfigurationsController : ApiController
    {


        [Route("GetByKmPriceType/{KmPriceType}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int kmPriceType)
        {
            var query = new GetAllKmPriceConfigurationsQuery { KmPriceTypeId = kmPriceType };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var query = new GetKmPriceConfigurationQuery { Id = id };
            var result = await Mediator.Send(query);

            return Ok(result);
        }


        [HttpPost]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateKmPriceConfigurationCommand createKmPriceConfigurationCommand)
        {
            await Mediator.Send(createKmPriceConfigurationCommand);

            return Ok();
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdateKmPriceConfigurationCommand updateKmPriceConfigurationCommand)
        {
            updateKmPriceConfigurationCommand.Id = id;
            await Mediator.Send(updateKmPriceConfigurationCommand);

            return Ok();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteKmPriceConfigurationCommand = new DeleteKmPriceConfigurationCommand { Id = id };
            await Mediator.Send(deleteKmPriceConfigurationCommand);

            return Ok();
        }
    }
}
