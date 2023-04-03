using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.AdminAggregate.PositionConfigurations.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.AdminAggregate.PositionConfigurations.Commands.CreatePositionConfiguration
{


    public class CreatePositionConfigurationCommandHandler : CommandHandler<CreatePositionConfigurationCommand>
    {


        public CreatePositionConfigurationCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        public override async Task<Unit> Handle(CreatePositionConfigurationCommand request, CancellationToken cancellationToken)
        {
            var reason = await this.GetReasonAsync(request.ReasonId);
            var concept = await this.GetConceptAsync(request.ConceptId);

            await this.RemoveConceptPositionAsync(request.ConceptId);

            foreach (var item in request.Positions)
            {
                var position = await this.GetPositionAsync(item);
                var entity = new PositionConfiguration(reason, concept, position);
                await _unitOfWork.Repository<PositionConfiguration>().AddAsync(entity);
            }
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

        private async Task RemoveConceptPositionAsync(int conceptId)
        {
            var positionConfigurationList = await _unitOfWork
                .Repository<PositionConfiguration>()
                .ListAsync(new PositionConfigurationByConceptSpecification(conceptId));

            foreach (var item in positionConfigurationList)
            {
                _unitOfWork.Repository<PositionConfiguration>().Delete(item);
            }
            await _unitOfWork.CommitAsync();
        }
        private async Task<Reason> GetReasonAsync(int reasonId)
        {
            var result = await FindById<Reason>(reasonId);
            Guard.Against.Null(result, nameof(reasonId));
            return result;
        }


        private async Task<Concept> GetConceptAsync(int conceptId)
        {
            var result = await FindById<Concept>(conceptId);
            Guard.Against.Null(result, nameof(conceptId));
            return result;
        }

        private async Task<Position> GetPositionAsync(int positionId)
        {
            var result = await FindById<Position>(positionId);
            Guard.Against.Null(result, nameof(positionId));
            return result;
        }
    }
}
