using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Commands.DeleteUser
{


    public class DeleteUserCommandHandler
        : CommandHandler<DeleteUserCommand>
    {
        private readonly IDateTime _dateTimeService;

        public DeleteUserCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IDateTime dateTimeService)
            : base(unitOfWork)
        {
            _dateTimeService = dateTimeService;
        }

        public async override Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork
               .Repository<User>()
               .ListAsync(new ByEmployeeRecordSpecification(request.EmployeeRecord));
            Guard.Against.Null(entities, nameof(request.EmployeeRecord));
            Guard.Against.UniqueUser(entities);

            var entity = entities.First();

            entity.Disable(_dateTimeService.Now);

            _unitOfWork.Repository<User>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
