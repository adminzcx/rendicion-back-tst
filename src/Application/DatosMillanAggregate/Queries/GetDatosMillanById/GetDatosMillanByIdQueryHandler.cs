using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.DatosMillanAggregate.Dtos;
using Prome.Viaticos.Server.Application.DatosMillanAggregate.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Prome.Viaticos.Server.Domain.Entities.DatosMillanAggregate;
using Ardalis.GuardClauses;
using System.Linq;
using Prome.Viaticos.Server.Application.DatosMillanAggregate.Guards;
using Prome.Viaticos.Server.Application.DatosMillanAggregate.Queries.GetDatosMillanById;

namespace Prome.Viaticos.Server.Application.DatosMillanAggregate.Queries.GetDatosMillanById
{
    public class GetDatosMillanByIdQueryHandler : QueryHandler<GetDatosMillanByIdQuery, DatosMillanDto>
    {

        public GetDatosMillanByIdQueryHandler(
         IAsyncUnitOfWork unitOfWork,
         IMapper mapper)
         : base(unitOfWork, mapper)
        { }

        public override async Task<DatosMillanDto> Handle(GetDatosMillanByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork
              .Repository<DatosMillan>()
              .SingleOrDefaultAsync(new DatosMillanByIdSpecification(request.Id));

            Guard.Against.Null(entities, nameof(request.Id));
            //Guard.Against.IsValidLegajo(entities);

            return Map(entities);
        }
    }
}
