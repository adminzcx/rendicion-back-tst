using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Commands.CreateRestaurant;
using Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Commands.DeleteRestaurant;
using Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Commands.UpdateRestaurant;
using Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Queries.GetAllRestaurant;
using Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Queries.GetRestaurants;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.LunchAggregate
{
    public class RestaurantController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllRestaurantQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetRestaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var query = new GetRestaurantQuery();
            query.Id = id;
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateRestaurantCommand createRestaurantCommand)
        {
            await Mediator.Send(createRestaurantCommand);

            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdateRestaurantCommand updateRestaurantCommand)
        {
            updateRestaurantCommand.Id = id;
            await Mediator.Send(updateRestaurantCommand);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteExpenseCommand = new DeleteRestaurantCommand
            {
                Id = id
            };

            await Mediator.Send(deleteExpenseCommand);

            return Ok();
        }
    }
}