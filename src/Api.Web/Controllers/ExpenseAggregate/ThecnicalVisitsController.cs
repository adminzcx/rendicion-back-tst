using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.ExpenseAggregate.TechnicalVisit.Queries.GetAllTechnicalVisits;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.ExpenseAggregate
{


    public class ThecnicalVisitsController : ApiController
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllTechnicalVisitsQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }


    }
}
