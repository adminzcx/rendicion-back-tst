using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.YPFRutaAggregate.Commands.CreateYPFRuta;
using Prome.Viaticos.Server.Application.YPFRutaAggregate.Commands.UpdateYPFRuta;
using Prome.Viaticos.Server.Application.YPFRutaAggregate.Queries.GetAllYPF;
using Prome.Viaticos.Server.Application.YPFRutaAggregate.Queries.GetYPFRutaById;
using Prome.Viaticos.Server.Application.YPFRutaAggregate.Queries.GetYPFRutaByTarjeta;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.YPFRutaController
{
    public class YPFRutaController : ApiController
    {
        [HttpPost]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateYPFRutaCommand createYPFRutaCommand)
        {
            await Mediator.Send(createYPFRutaCommand);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllYPFQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [Route("GetYPFById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetYPFRutaById(int id)
        {
            var query = new GetYPFRutaByIdQuery() { Id = id };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetByTarjeta/{tarjeta}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByTarjeta(string tarjeta)
        {
            var query = new GetYPFRutaByTarjetaQuery
            {
                Identificacion_Tarjeta = tarjeta
            };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdateYPFRutaCommand updateYPFRutaCommand)
        {
            updateYPFRutaCommand.Id = id;
            await Mediator.Send(updateYPFRutaCommand);

            return Ok();
        }
    }
}
