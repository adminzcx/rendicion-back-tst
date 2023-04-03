using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.PathExpenseFormPaidStatus
{

    public class PathExpenseFormPaidStatusCommandHandler : CommandHandler<PathExpenseFormPaidStatusCommand>
    {



        public PathExpenseFormPaidStatusCommandHandler(
            IAsyncUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public override async Task<Unit> Handle(PathExpenseFormPaidStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await FindById<Domain.Entities.ExpenseFormAggregate.ExpenseForm>(request.Id);
            entity.IsPaid = request.Paid;
            _unitOfWork.Repository<Domain.Entities.ExpenseFormAggregate.ExpenseForm>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

    }
}
