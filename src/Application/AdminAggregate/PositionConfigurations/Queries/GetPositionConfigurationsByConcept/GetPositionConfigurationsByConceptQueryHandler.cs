

using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.AdminAggregate.PositionConfigurations.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.AdminAggregate.PositionConfigurations.Queries.GetPositionConfigurationsByConcept
{

    public class GetPositionConfigurationsByConceptQueryHandler : QueryHandler<GetPositionConfigurationsByConceptQuery, ICollection<SelectedPositionDto>>
    {
        public GetPositionConfigurationsByConceptQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<SelectedPositionDto>> Handle(GetPositionConfigurationsByConceptQuery request, CancellationToken cancellationToken)
        {
            var positionList = await _unitOfWork
                .Repository<Position>()
                .ListAllAsync();

            var list = _mapper.Map<List<SelectedPositionDto>>(positionList);

            var positionConfigurationList = await _unitOfWork
                .Repository<PositionConfiguration>()
                .ListAsync(new PositionConfigurationByConceptSpecification(request.ConceptId));

            foreach (var item in list)
            {
                item.IsSelected = positionConfigurationList.Any(x => x.Position.Id == item.Id);
            }

            return list;
        }


    }
}
