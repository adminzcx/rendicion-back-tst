using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Branch.Queries.GetAllBranches;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.ExpenseAggregate
{
    public class BranchesController : ApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllBranchesQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}