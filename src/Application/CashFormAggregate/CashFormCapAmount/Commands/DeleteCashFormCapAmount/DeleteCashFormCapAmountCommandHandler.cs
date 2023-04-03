using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Commands.DeleteCashFormAmount
{
    public class DeleteCashFormCapAmountCommandHandler : CommandHandler<DeleteCashFormCapAmountCommand>
    {
        public DeleteCashFormCapAmountCommandHandler(
            IAsyncUnitOfWork unitOfWork
           )
            : base(unitOfWork)
        {
        }

        public async override Task<Unit> Handle(DeleteCashFormCapAmountCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
              .Repository<Domain.Entities.CashFormAggregate.CashFormCapAmount>()
              .GetByIdAsync(request.Id);
            Guard.Against.Null(entity, nameof(request.Id));


            entity.IsDeleted = true;

            _unitOfWork.Repository<Domain.Entities.CashFormAggregate.CashFormCapAmount>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
