using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Commands.CreateCuentaCorriente;
using Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Commands.DeleteCurrentAccount;
using Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Commands.UpdateCuentaCorriente;
using Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Queries.GetAllCuentasCorrientes;
using Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Queries.GetCuentasCorrientesByUser;
using Prome.Viaticos.Server.Application.YPFRutaAggregate.Commands.UpdateDataYPF;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Controllers.CuentasCorrientesController
{
    public class CuentasCorrientesController : ApiController
    {
        [HttpPost]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateCuentaCorrienteCommand createCuentaCorrienteCommand)
        {
            await Mediator.Send(createCuentaCorrienteCommand);
            return Ok();
        }

        [HttpPut("{id}")]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdateCuentaCorrienteCommand updateYPFRutaCommand)
        {
            updateYPFRutaCommand.Id = id;
            await Mediator.Send(updateYPFRutaCommand);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCuentasCorrientesQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [Route("GetCuentasCorrientesByLegajo/{legajo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCuentasCorrientesByLegajo(int legajo)
        {
            var query = new GetCuentasCorrientesByLegajoQuery() { Legajo = legajo };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [Route("GetCuentasCorrientesById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCuentasCorrientesById(int id)
        {
            var query = new GetCuentasCorrientesByIdQuery() { Id = id };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteCurrentAccountCommand = new DeleteCurrentAccountCommand
            {
                Id = id
            };

            await Mediator.Send(deleteCurrentAccountCommand);

            return Ok();
        }

        [HttpPost]
        [Route("UpdateDatosYPF")]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateDatosYPF(UpdateDataYPFCommand updateDataYPFCommand)
        {
            await Mediator.Send(updateDataYPFCommand);
            return Ok();
        }
    }
}
