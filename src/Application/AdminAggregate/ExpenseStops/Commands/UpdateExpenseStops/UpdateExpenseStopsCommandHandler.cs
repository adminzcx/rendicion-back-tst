using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Commands.UpdateExpenseStops
{
    public class UpdateExpenseStopsCommandHandler : CommandHandler<UpdateExpenseStopsCommand>
    {
        public UpdateExpenseStopsCommandHandler(
            IAsyncUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

        public async override Task<Unit> Handle(UpdateExpenseStopsCommand request, CancellationToken cancellationToken)
        {

            var entity = await _unitOfWork
              .Repository<Domain.Entities.AdminAggregate.ExpenseStops>()
              .GetByIdAsync(request.Id);
            Guard.Against.Null(entity, nameof(request.Id));

            var reason = await this.GetReasonAsync(request.ReasonId);
            var concept = await this.GetConceptAsync(request.ConceptId);

            entity.Reason = reason;
            entity.Concept = concept;
            entity.ValidityStartDate = request.ValidityStartDate;
            entity.CapAmount = request.CapAmount;

            _unitOfWork.Repository<Domain.Entities.AdminAggregate.ExpenseStops>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
        private async Task<Concept> GetConceptAsync(int conceptId)
        {
            var result = await FindById<Concept>(conceptId);
            Guard.Against.Null(result, nameof(conceptId));
            return result;
        }
        private async Task<Reason> GetReasonAsync(int reasonId)
        {
            var result = await FindById<Reason>(reasonId);
            Guard.Against.Null(result, nameof(reasonId));
            return result;
        }
    }
}
