using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.DatosMillanAggregate.GetAllDatosMillan;
using Prome.Viaticos.Server.Application.DatosMillanAggregate.Commands.UpdateUser;
using Prome.Viaticos.Server.Application.DatosMillanAggregate.Commands.CreateUser;
using System.Threading.Tasks;
using Prome.Viaticos.Server.Application.DatosMillanAggregate.Queries.GetDatosMillanById;
using System;

namespace Prome.Viaticos.Server.Api.Web.Controllers.DatosMillanAggregate
{
    public class DatosMillanController : ApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {        
            var query = new GetAllDatosMillanQuery();
            var result = await Mediator.Send(query);            
            
            return Ok(result);
        }


        [HttpPut("{id}")]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdateDatosMillanCommand updateDatosMillanCommand)
        {
            updateDatosMillanCommand.Id = id;
            await Mediator.Send(updateDatosMillanCommand);

            return Ok();
        }


        [Route("GetDatosMillanById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDatosMillanByIdQuery(int id)
        {
            var query = new GetDatosMillanByIdQuery { Id = id };
            var result = await Mediator.Send(query);

            return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateDatosMillanCommand createDatosMillanCommand)
        {
            await Mediator.Send(createDatosMillanCommand);

            return Ok();
        }





        //[HttpGet("{id}", Name = "Get")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public string Get(int id)
        //{

        //    return "value";
        //}
    }

}
