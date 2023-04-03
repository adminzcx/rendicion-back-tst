using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Commands.DeleteLunch
{
    public class DeleteLunchCommandHandler : CommandHandler<DeleteLunchCommand>
    {


        public DeleteLunchCommandHandler(IAsyncUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        public async override Task<Unit> Handle(DeleteLunchCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
              .Repository<Domain.Entities.LunchAggregate.Lunch>()
              .GetByIdAsync(request.Id);
            Guard.Against.Null(entity, nameof(request.Id));


            entity.IsDeleted = true;

            _unitOfWork.Repository<Domain.Entities.LunchAggregate.Lunch>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
