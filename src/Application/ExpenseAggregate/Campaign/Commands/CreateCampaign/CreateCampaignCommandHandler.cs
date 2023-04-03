using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Campaign.Commands.CreateCampaign
{
    public class CreateCampaignCommandHandler : CommandHandler<CreateCampaignCommand>
    {


        public CreateCampaignCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        public override async Task<Unit> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {

            var entity = new Domain.Entities.ExpenseAggregate.Campaign(request.Name);

            await _unitOfWork.Repository<Domain.Entities.ExpenseAggregate.Campaign>().AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

    }
}
