using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.YPFRutaAggregate.Dtos;
using Prome.Viaticos.Server.Domain.Entities.YPFRutaAggregate;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.YPFRutaAggregate.Queries.GetAllYPF
{
    public class GetAllYPFQueryHandler : QueryHandler<GetAllYPFQuery, ICollection<YPFRutaDto>>
    {
        public GetAllYPFQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<YPFRutaDto>> Handle(GetAllYPFQuery request, CancellationToken cancellationToken)
        {

            var list = await _unitOfWork
             .Repository<Datos_YPF>()
             .ListAllAsync();


            return Map(list);
        }
    }
}
