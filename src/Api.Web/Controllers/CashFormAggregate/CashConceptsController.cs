using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashConcept.Queries.GetAllCashConcepts;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.CashFormAggregate
{


    public class CashConceptsController : ApiController
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCashConceptsQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

    }
}
