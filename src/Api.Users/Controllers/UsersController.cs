using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Commands.CreateUser;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Commands.DeleteUser;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Commands.PatchUser;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Commands.UpdateUser;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetAllUsers;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Queries.GetUserByEmail;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Users.Controllers
{


    [Authorize]
    public class UsersController : ApiController
    {
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

        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public string Get(int id)
        {

            return "value";
        }

        [HttpGet]
        [Route("GetByEmail/{Email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var query = new GetUserByEmailQuery { Email = email };
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

        [HttpPut("{employeeRecord}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(string employeeRecord, UpdateUserCommand updateUserCommand)
        {
            updateUserCommand.EmployeeRecord = employeeRecord;
            await Mediator.Send(updateUserCommand);

            return Ok();
        }


        [HttpPatch("{employeeRecord}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Patch(string employeeRecord, PatchUserCommand patchUserCommand)
        {
            patchUserCommand.EmployeeRecord = employeeRecord;
            await Mediator.Send(patchUserCommand);

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
