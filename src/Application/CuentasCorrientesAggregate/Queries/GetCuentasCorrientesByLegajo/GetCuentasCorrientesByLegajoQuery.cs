using MediatR;
using Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Dtos;
using System;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Queries.GetCuentasCorrientesByUser
{
    public class GetCuentasCorrientesByLegajoQuery : IRequest<ICollection<CuentasCorrientesByUserDto>>
    {
        public int Legajo { get; set; }
    }
}
