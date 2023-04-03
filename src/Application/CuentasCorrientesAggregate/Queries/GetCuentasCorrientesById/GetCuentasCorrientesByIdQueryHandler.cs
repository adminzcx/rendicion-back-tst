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
    public class GetCuentasCorrientesByIdQueryHandler : QueryHandler<GetCuentasCorrientesByIdQuery, CuentasCorrientesByUserDto>
    {
        public GetCuentasCorrientesByIdQueryHandler(
         IAsyncUnitOfWork unitOfWork,
         IMapper mapper)
         : base(unitOfWork, mapper)
        { }

        public override async Task<CuentasCorrientesByUserDto> Handle(GetCuentasCorrientesByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork
              .Repository<CuentasCorrientes>()
              .SingleOrDefaultAsync(new ByIdSpecification(request.Id));

            Guard.Against.Null(entities, nameof(request.Id));
            //Guard.Against.IsValidLegajo(entities);

            return Map(entities);
        }
    }
}
