using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Commands.PathLunchFormPaidStatus
{

    public class PathLunchFormPaidStatusCommandHandler : CommandHandler<PathLunchFormPaidStatusCommand>
    {



        public PathLunchFormPaidStatusCommandHandler(
            IAsyncUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public override async Task<Unit> Handle(PathLunchFormPaidStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await FindById<Domain.Entities.LunchFormAggregate.LunchForm>(request.Id);
            entity.IsPaid = request.Paid;
            _unitOfWork.Repository<Domain.Entities.LunchFormAggregate.LunchForm>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

    }
}
