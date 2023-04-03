using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Commands.CreateUserSubstitution
{


    public class CreateUserSubstitutionCommandHandler : CommandHandler<CreateUserSubstitutionCommand>
    {
        public CreateUserSubstitutionCommandHandler(
            IAsyncUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

        public override async Task<Unit> Handle(CreateUserSubstitutionCommand request, CancellationToken cancellationToken)
        {
            var user = await this.GetUserAsync(request.UserId);
            var replaceByUser = await this.GetUserAsync(request.ReplaceByUserId);

            UserSubstitution entity = new UserSubstitution(user, replaceByUser);
            await _unitOfWork.Repository<UserSubstitution>().AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

        private async Task<User> GetUserAsync(int id)
        {
            var result = await FindById<User>(id);
            Guard.Against.Null(result, nameof(id));
            return result;
        }
    }
}
