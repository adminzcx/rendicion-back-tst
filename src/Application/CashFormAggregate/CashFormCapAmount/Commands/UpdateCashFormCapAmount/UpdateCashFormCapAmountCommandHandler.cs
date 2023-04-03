using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Commands.UpdateCashFormCapAmount
{
    public class UpdateCashFormCapAmountCommandHandler : CommandHandler<UpdateCashFormCapAmountCommand>
    {
        public UpdateCashFormCapAmountCommandHandler(
            IAsyncUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

        public async override Task<Unit> Handle(UpdateCashFormCapAmountCommand request, CancellationToken cancellationToken)
        {

            var entity = await _unitOfWork
              .Repository<Domain.Entities.CashFormAggregate.CashFormCapAmount>()
              .GetByIdAsync(request.Id);
            Guard.Against.Null(entity, nameof(request.Id));


            entity.Amount = request.Amount;
            entity.Date = request.Date;

            _unitOfWork.Repository<Domain.Entities.CashFormAggregate.CashFormCapAmount>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
