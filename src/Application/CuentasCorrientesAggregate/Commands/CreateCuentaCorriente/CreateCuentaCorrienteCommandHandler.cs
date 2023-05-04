using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Commands.CreateCuentaCorriente
{
    public class CreateCuentaCorrienteCommandHandler : CommandHandler<CreateCuentaCorrienteCommand>
    {
        public CreateCuentaCorrienteCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper
           )
            : base(unitOfWork, mapper)
        {

        }
        public override async Task<Unit> Handle(CreateCuentaCorrienteCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.CuentaCorrienteAggregate.CuentasCorrientes>(request);

            await _unitOfWork.Repository<Domain.Entities.CuentaCorrienteAggregate.CuentasCorrientes>().AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
