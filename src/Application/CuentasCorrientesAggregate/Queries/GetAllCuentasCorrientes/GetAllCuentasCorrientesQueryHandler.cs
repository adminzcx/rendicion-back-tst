using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Dtos;
using Prome.Viaticos.Server.Domain.Entities.CuentaCorrienteAggregate;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Queries.GetAllCuentasCorrientes
{
    public class GetAllCuentasCorrientesQueryHandler : QueryHandler<GetAllCuentasCorrientesQuery, ICollection<CuentasCorrientesDto>>
    {
        public GetAllCuentasCorrientesQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<CuentasCorrientesDto>> Handle(GetAllCuentasCorrientesQuery request, CancellationToken cancellationToken)
        {

            var list = await _unitOfWork
             .Repository<CuentasCorrientes>()
             .ListAllAsync();


            return Map(list);
        }
    }
}
