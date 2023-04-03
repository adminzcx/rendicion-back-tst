using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Commands.CreateUserSubstitution;
using Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Commands.DeleteUserSubstitution;
using Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Queries.GetAllUserSubstitution;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.AdminAggregate
{



    public class UserSubstitutionsController : ApiController
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllUserSubstitutionQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateUserSubstitutionCommand createUserSubstitutionCommand)
        {

            await Mediator.Send(createUserSubstitutionCommand);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteUserSubstitutionCommand = new DeleteUserSubstitutionCommand
            {
                Id = id
            };

            await Mediator.Send(deleteUserSubstitutionCommand);

            return Ok();
        }
    }
}
