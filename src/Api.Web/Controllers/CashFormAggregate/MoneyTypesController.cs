using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.CashFormAggregate.MoneyType.Queries.GetAllMoneyTypes;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.CashFormAggregate
{


    public class MoneyTypesController : ApiController
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllMoneyTypesQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

    }
}
