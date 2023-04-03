using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Commands.CreateExpenseStops;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.AdminAggregate.Stops.Commands.CreateExpenseStops
{


    public class CreateExpenseStopsCommandHandler : CommandHandler<CreateExpenseStopsCommand>
    {


        public CreateExpenseStopsCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper
            )
            : base(unitOfWork, mapper)
        {

        }

        public override async Task<Unit> Handle(CreateExpenseStopsCommand request, CancellationToken cancellationToken)
        {
            var reason = await this.GetReasonAsync(request.ReasonId);
            var concept = await this.GetConceptAsync(request.ConceptId);
            var entity = _mapper.Map<Domain.Entities.AdminAggregate.ExpenseStops>(request);
            entity.Reason = reason;
            entity.Concept = concept;

            await _unitOfWork.Repository<Domain.Entities.AdminAggregate.ExpenseStops>().AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
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

    }
}
