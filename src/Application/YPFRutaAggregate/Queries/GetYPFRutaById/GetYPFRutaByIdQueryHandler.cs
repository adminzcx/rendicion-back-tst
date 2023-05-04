using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.YPFRutaAggregate.Dtos;
using Prome.Viaticos.Server.Application.YPFRutaAggregate.Specifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Prome.Viaticos.Server.Domain.Entities.YPFRutaAggregate;
using Ardalis.GuardClauses;
using System.Linq;
using Prome.Viaticos.Server.Application.YPFRutaAggregate.Guards;
using Prome.Viaticos.Server.Application.YPFRutaAggregate.Queries.GetYPFRutaById;

namespace Prome.Viaticos.Server.Application.YPFRutaAggregate.Queries.GetYPFById
{
    public class GetYPFRutaByIdQueryHandler : QueryHandler<GetYPFRutaByIdQuery, YPFRutaDto>
    {
        public GetYPFRutaByIdQueryHandler(
         IAsyncUnitOfWork unitOfWork,
         IMapper mapper)
         : base(unitOfWork, mapper)
        { }

        public override async Task<YPFRutaDto> Handle(GetYPFRutaByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork
              .Repository<Datos_YPF>()
              .SingleOrDefaultAsync(new ByIdSpecification(request.Id));

            Guard.Against.Null(entities, nameof(request.Id));
            //Guard.Against.IsValidLegajo(entities);

            return Map(entities);
        }
    }
}
