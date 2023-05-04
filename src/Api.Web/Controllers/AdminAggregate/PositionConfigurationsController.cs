using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.AdminAggregate.PositionConfigurations.Commands.CreatePositionConfiguration;
using Prome.Viaticos.Server.Application.AdminAggregate.PositionConfigurations.Queries.GetPositionConfigurationsByConcept;
using Prome.Viaticos.Server.Application.UserAggregate.Positions.Queries.GetAllPositions;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.AdminAggregate
{



    public class PositionConfigurationsController : ApiController
    {

        [HttpGet]
        [Route("GetByConcept/{ConceptId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByReason(int conceptId)
        {
            var query = new GetPositionConfigurationsByConceptQuery { ConceptId = conceptId };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreatePositionConfigurationCommand createPositionConfigurationCommand)
        {
            await Mediator.Send(createPositionConfigurationCommand);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllPositions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllPositions()
        {
            var query = new GetAllPositionsQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
