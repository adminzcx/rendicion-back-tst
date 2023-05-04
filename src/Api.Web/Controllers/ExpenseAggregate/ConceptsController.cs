using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Queries.GetAllConcepts;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Queries.GetConceptsByReason;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Queries.GetConceptsPositionByReason;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.ExpenseAggregate
{

    public class ConceptsController : ApiController
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllConceptsQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetByReason/{ReasonId}/{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByReason(int reasonId, string user)
        {
            var query = new GetConceptsPositionByReasonQuery
            {
                Email = this.GetUserAuthorized(user),
                ReasonId = reasonId
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllByReason/{ReasonId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllByReason(int reasonId)
        {

            var query = new GetConceptsByReasonQuery
            {
                ReasonId = reasonId
            };
            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
