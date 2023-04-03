using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Commands.UpdateLunchStops
{
    public class UpdateLunchStopsCommandHandler : CommandHandler<UpdateLunchStopsCommand>
    {
        public UpdateLunchStopsCommandHandler(
            IAsyncUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public async override Task<Unit> Handle(UpdateLunchStopsCommand request, CancellationToken cancellationToken)
        {

            var entity = await _unitOfWork
              .Repository<Domain.Entities.AdminAggregate.LunchStops>()
              .GetByIdAsync(request.Id);
            Guard.Against.Null(entity, nameof(request.Id));

            entity.ValidityStartDate = request.ValidityStartDate;
            entity.CapAmount = request.CapAmount;
            entity.IsMonthly = request.IsMonthly;


            _unitOfWork.Repository<Domain.Entities.AdminAggregate.LunchStops>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
