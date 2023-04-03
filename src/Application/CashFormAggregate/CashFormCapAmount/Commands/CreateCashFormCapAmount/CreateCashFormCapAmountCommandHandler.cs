using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Commands.CreateCashFormCapAmount
{
    public class CreateCashFormCapAmountCommandHandler : CommandHandler<CreateCashFormCapAmountCommand>
    {
        public CreateCashFormCapAmountCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper
            )
                : base(unitOfWork, mapper)
        {

        }

        public override async Task<Unit> Handle(CreateCashFormCapAmountCommand request, CancellationToken cancellationToken)
        {

            var entity = _mapper.Map<Domain.Entities.CashFormAggregate.CashFormCapAmount>(request);

            await _unitOfWork.Repository<Domain.Entities.CashFormAggregate.CashFormCapAmount>().AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
