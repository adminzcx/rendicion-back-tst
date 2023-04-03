using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Campaign.Commands.UpdateCampaign
{

    public class UpdateCampaignCommandHandler : CommandHandler<UpdateCampaignCommand>
    {
        public UpdateCampaignCommandHandler(
            IAsyncUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

        public async override Task<Unit> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
              .Repository<Domain.Entities.ExpenseAggregate.Campaign>()
              .GetByIdAsync(request.Id);

            entity.Name = request.Name;

            _unitOfWork.Repository<Domain.Entities.ExpenseAggregate.Campaign>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
