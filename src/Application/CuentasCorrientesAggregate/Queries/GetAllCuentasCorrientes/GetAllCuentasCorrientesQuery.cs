using MediatR;
using System.Collections.Generic;
using Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Dtos;

namespace Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Queries.GetAllCuentasCorrientes
{
    public class GetAllCuentasCorrientesQuery : IRequest<ICollection<CuentasCorrientesDto>>
    {
    }
}
