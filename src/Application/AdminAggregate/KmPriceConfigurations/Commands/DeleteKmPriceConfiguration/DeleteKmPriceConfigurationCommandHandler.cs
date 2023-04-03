using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Commands.DeleteKmPriceConfiguration
{
    public class DeleteKmPriceConfigurationCommandHandler
        : CommandHandler<DeleteKmPriceConfigurationCommand>
    {


        public DeleteKmPriceConfigurationCommandHandler(
            IAsyncUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public async override Task<Unit> Handle(DeleteKmPriceConfigurationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
              .Repository<KmPriceConfiguration>()
              .GetByIdAsync(request.Id);
            Guard.Against.Null(entity, nameof(request.Id));

            entity.IsDeleted = true;

            _unitOfWork.Repository<KmPriceConfiguration>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
