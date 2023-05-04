using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.DatosMillanAggregate.Dtos;
using System.Threading;
using System.Threading.Tasks;
using Prome.Viaticos.Server.Domain.Entities.DatosMillanAggregate;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.DatosMillanAggregate.GetAllDatosMillan
{

    public class GetAllDatosMillanQueryHandler : QueryHandler<GetAllDatosMillanQuery, ICollection<DatosMillanDto>>
    {
        public GetAllDatosMillanQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }


        public override async Task<ICollection<DatosMillanDto>> Handle(GetAllDatosMillanQuery request, CancellationToken cancellationToken)
        {

            var list = await _unitOfWork
             .Repository<DatosMillan>()
             .ListAllAsync();


            return Map(list);
        }
        //public override async Task<DatosMillanDto> Handle(GetAllDatosMillanQuery request, CancellationToken cancellationToken)
        //{
        //    var vm = await _unitOfWork
        //        .Repository<DatosMillan>()
        //        .ListAllAsync();

        //    return Map(vm);
        //}
    }



}

