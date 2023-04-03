using Ardalis.GuardClauses;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.YPFRutaAggregate.Guards;
using Prome.Viaticos.Server.Application.YPFRutaAggregate.Dtos;
using Prome.Viaticos.Server.Application.YPFRutaAggregate.Specifications;
using Prome.Viaticos.Server.Domain.Entities.YPFRutaAggregate;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.YPFRutaAggregate.Queries.GetYPFRutaByTarjeta
{
    class GetYPFRutaByTarjetaQueryHandler : QueryHandler<GetYPFRutaByTarjetaQuery, YPFRutaDto>
    {
        public GetYPFRutaByTarjetaQueryHandler(
         IAsyncUnitOfWork unitOfWork,
         IMapper mapper)
         : base(unitOfWork, mapper)
        { }

        public override async Task<YPFRutaDto> Handle(GetYPFRutaByTarjetaQuery request, CancellationToken cancellationToken)
        {

            var entities = await _unitOfWork
              .Repository<Datos_YPF>()
              .ListAsync(new ByTarjetaSpecification(request.Identificacion_Tarjeta));

            Guard.Against.Null(entities, nameof(request.Identificacion_Tarjeta));
            Guard.Against.IsValidYPFRuta(entities);

            var entity = entities.First();

            return Map(entity);
        }
    }
}
