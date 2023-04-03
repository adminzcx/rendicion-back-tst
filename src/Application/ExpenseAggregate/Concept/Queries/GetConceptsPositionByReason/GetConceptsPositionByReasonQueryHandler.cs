
using Ardalis.GuardClauses;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.AdminAggregate.PositionConfigurations.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Dtos;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Specifications;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Queries.GetConceptsPositionByReason
{
    public class GetConceptsPositionByReasonQueryHandler : QueryHandler<GetConceptsPositionByReasonQuery, ICollection<ConceptDto>>
    {
        public GetConceptsPositionByReasonQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<ConceptDto>> Handle(GetConceptsPositionByReasonQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await GetCurrentUserAsync((request.Email));
            var enabledConcepts = await GetEnabledConceptsAsync((currentUser));

            var list = await _unitOfWork
                .Repository<Domain.Entities.ExpenseAggregate.Concept>()
                .ListAsync(new ConceptByPositionSpecification(request.ReasonId, enabledConcepts));

            return Map(list);
        }

        private async Task<List<long>> GetEnabledConceptsAsync(User currentUser)
        {
            var positionConfigurationList = await _unitOfWork
                .Repository<PositionConfiguration>()
                .ListAsync(new PositionConfigurationByPositionSpecification(currentUser.Position.Id));

            Guard.Against.Null(positionConfigurationList, nameof(positionConfigurationList));
            return positionConfigurationList.Select(x => x.Concept.Id).ToList();
        }

        private async Task<User> GetCurrentUserAsync(string email)
        {
            var users = await _unitOfWork
                .Repository<User>()
                .ListAsync(new ByEmployeeEmailSpecification(email));

            Guard.Against.Null(users, nameof(email));
            Guard.Against.IsValidUser(users);

            return users.First();
        }
    }
}
