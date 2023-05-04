using Prome.Viaticos.Server.Application._Common.Handlers;
using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Guards;
using System.Threading;
using System.Threading.Tasks;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;

namespace Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Commands.UpdateCuentaCorriente
{
    public class UpdateYPFRutaCommandHandler : CommandHandler<UpdateCuentaCorrienteCommand>
    {
        private readonly IDateTime _dateTimeService;

        public UpdateYPFRutaCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper,
            IDateTime dateTimeService)
            : base(unitOfWork, mapper)
        {
            _dateTimeService = dateTimeService;
        }

        public override async Task<Unit> Handle(UpdateCuentaCorrienteCommand request, CancellationToken cancellationToken)
        {
            var entity = await FindById<Domain.Entities.CuentaCorrienteAggregate.CuentasCorrientes>(request.Id);

            var reason = await FindById<Reason>(request.ReasonId);
            Guard.Against.Null(reason, nameof(request.ReasonId));

            entity.Fecha = request.Fecha;
            entity.Legajo = request.Legajo;
            entity.Monto = request.Monto;
            entity.Observaciones = request.Observaciones;
            entity.Reason = reason;

            _unitOfWork.Repository<Domain.Entities.CuentaCorrienteAggregate.CuentasCorrientes>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
