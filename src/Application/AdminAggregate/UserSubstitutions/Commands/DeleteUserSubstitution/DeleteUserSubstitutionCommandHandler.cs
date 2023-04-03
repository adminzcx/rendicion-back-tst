using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Commands.DeleteUserSubstitution
{


    public class DeleteUserSubstitutionCommandHandler
        : CommandHandler<DeleteUserSubstitutionCommand>
    {


        public DeleteUserSubstitutionCommandHandler(
            IAsyncUnitOfWork unitOfWork
           )
            : base(unitOfWork)
        {

        }

        public async override Task<Unit> Handle(DeleteUserSubstitutionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
              .Repository<UserSubstitution>()
              .GetByIdAsync(request.Id);
            Guard.Against.Null(entity, nameof(request.Id));

            entity.IsDeleted = true;

            _unitOfWork.Repository<UserSubstitution>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
