using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Commands.CreateUser;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Commands.DeleteUser;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Commands.UpdateUser;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetAllActiveUsers;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetAllUsers;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetUser;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetUserByEmail;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetUsersByBranchUser;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetUsersByExcludeBranchUser;
using System;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.UserAggregate
{


    public class UsersController : ApiController
    {

        [HttpGet("Login/{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(string user)
        {
            var query = new GetUserByEmailQuery { Email = this.GetUserAuthorized(user) };
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

        [Route("GetUsersByBranchUser/{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsersByBranchUser(string user)
        {
            var query = new GetUsersByBranchUserQuery()
            {
                Email = this.GetUserAuthorized(user)
            };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Route("GetUsersByExcludedBranchUser/{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsersByExcludedBranchUser(string user)
        {
            var query = new GetUsersByExcludeBranchUserQuery()
            {
                Email = this.GetUserAuthorized(user)
            };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Route("GetUserById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var query = new GetUserQuery { Id = id };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateUserCommand createUserCommand)
        {
            await Mediator.Send(createUserCommand);

            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdateUserCommand updateUserCommand)
        {
            updateUserCommand.Id = id;
            await Mediator.Send(updateUserCommand);

            return Ok();
        }

        [HttpDelete("{employeeRecord}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(string employeeRecord)
        {
            var deleteUserCommand = new DeleteUserCommand
            {
                EmployeeRecord = employeeRecord
            };

            await Mediator.Send(deleteUserCommand);

            return Ok();
        }
    }
}
