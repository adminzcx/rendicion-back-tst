using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Dtos;
using Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Specifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Prome.Viaticos.Server.Domain.Entities.CuentaCorrienteAggregate;
using Ardalis.GuardClauses;
using System.Linq;
using Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Guards;

namespace Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Queries.GetCuentasCorrientesByUser
{
    public class GetCuentasCorrientesByLegajoQueryHandler : QueryHandler<GetCuentasCorrientesByLegajoQuery, ICollection<CuentasCorrientesByUserDto>>
    {
        public GetCuentasCorrientesByLegajoQueryHandler(
         IAsyncUnitOfWork unitOfWork,
         IMapper mapper)
         : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<CuentasCorrientesByUserDto>> Handle(GetCuentasCorrientesByLegajoQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork
              .Repository<CuentasCorrientes>()
              .ListAsync(new ByLegajoSpecification(request.Legajo));

            Guard.Against.Null(entities, nameof(request.Legajo));
            //Guard.Against.IsValidLegajo(entities);

            return Map(entities);
        }
    }
}
