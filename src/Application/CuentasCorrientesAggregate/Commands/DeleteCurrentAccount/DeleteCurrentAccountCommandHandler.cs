using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.Entities.CuentaCorrienteAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Commands.DeleteCurrentAccount
{
    public class DeleteCurrentAccountCommandHandler : CommandHandler<DeleteCurrentAccountCommand>
    {
        private readonly IDateTime _dateTimeService;

        public DeleteCurrentAccountCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IDateTime dateTimeService)
            : base(unitOfWork)
        {
            _dateTimeService = dateTimeService;
        }

        public async override Task<Unit> Handle(DeleteCurrentAccountCommand request, CancellationToken cancellationToken)
        {
            //var entities = await _unitOfWork
            //   .Repository<CuentasCorrientes>()
            //   .ListAsync(new ByEmployeeRecordSpecification(request.Id));
            //Guard.Against.Null(entities, nameof(request.Id));
            //Guard.Against.UniqueUser(entities);

            //var entity = entities.First();

            //entity.Disable(_dateTimeService.Now);

            //_unitOfWork.Repository<>().Update(entity);
            //await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
