using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Campaign.Commands.DeleteCampaign
{


    public class DeleteCampaignCommandHandler
        : CommandHandler<DeleteCampaignCommand>
    {


        public DeleteCampaignCommandHandler(
            IAsyncUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public async override Task<Unit> Handle(DeleteCampaignCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
              .Repository<Domain.Entities.ExpenseAggregate.Campaign>()
              .GetByIdAsync(request.Id);
            Guard.Against.Null(entity, nameof(request.Id));

            entity.IsDeleted = true;

            _unitOfWork.Repository<Domain.Entities.ExpenseAggregate.Campaign>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
