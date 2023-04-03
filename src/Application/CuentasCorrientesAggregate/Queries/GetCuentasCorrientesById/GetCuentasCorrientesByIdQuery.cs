using MediatR;
using Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Dtos;
using System;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Queries.GetCuentasCorrientesByUser
{
    public class GetCuentasCorrientesByIdQuery : IRequest<CuentasCorrientesByUserDto>
    {
        public int Id { get; set; }
    }
}
