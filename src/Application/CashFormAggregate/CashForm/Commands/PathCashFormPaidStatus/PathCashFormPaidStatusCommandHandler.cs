using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Commands.PathCashFormPaidStatus
{

    public class PathCashFormPaidStatusCommandHandler : CommandHandler<PathCashFormPaidStatusCommand>
    {



        public PathCashFormPaidStatusCommandHandler(
            IAsyncUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public override async Task<Unit> Handle(PathCashFormPaidStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await FindById<Domain.Entities.CashFormAggregate.CashForm>(request.Id);
            entity.IsPaid = request.Paid;
            _unitOfWork.Repository<Domain.Entities.CashFormAggregate.CashForm>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

    }
}
