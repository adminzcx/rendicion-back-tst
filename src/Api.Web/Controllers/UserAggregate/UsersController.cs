using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetAllActiveUsers;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetAllUsers;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetUserByEmail;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetUsersByBranchUser;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetUsersByExcludeBranchUser;
using System;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.UserAggregate
{


    public class UsersController : ApiController
    {

        [HttpGet("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login()
        {

            var query = new GetUserByEmailQuery { Email = this.GetUserAuthorized() };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllUsersQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [Route("GetActiveUsers/{Date}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetActiveUsers(DateTime date)
        {
            var query = new GetAllActiveUsersQuery { Date = date };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [Route("GetAllActiveUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllActiveUsers()
        {
            var query = new GetAllActiveUsersQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [Route("GetUsersByBranchUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsersByBranchUser()
        {
            var query = new GetUsersByBranchUserQuery()
            {
                Email = this.GetUserAuthorized()
            };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Route("GetUsersByExcludedBranchUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsersByExcludedBranchUser()
        {
            var query = new GetUsersByExcludeBranchUserQuery()
            {
                Email = this.GetUserAuthorized()
            };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
