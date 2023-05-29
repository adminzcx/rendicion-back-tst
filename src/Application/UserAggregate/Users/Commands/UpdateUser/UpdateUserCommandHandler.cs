using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Commands.UpdateUser
{

    public class UpdateUserCommandHandler : CommandHandler<UpdateUserCommand>
    {
        public UpdateUserCommandHandler(
            IAsyncUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

        public async override Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await FindById<User>(request.Id);

            var branchFrom = await FindByCode<Branch>(request.BranchFrom);
            Guard.Against.Null(branchFrom, nameof(request.BranchFrom));

            var position = await FindByCode<Position>(request.Position);
            Guard.Against.Null(position, nameof(request.Position));

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Email = request.Email;
            entity.IsAdministrator = request.IsAdministrator;
            entity.Branch = branchFrom;
            entity.Position = position;
            entity.Cuit = request.Cuit;
            entity.TarjetaYPF = request.TarjetaYPF;
            entity.YPFRuta = request.YPFRuta;
            entity.Clean();

            if (request.Category != null)
            {
                var category = await FindByCode<Category>(request.Category);
                Guard.Against.Null(category, nameof(request.Category));
                entity.Category = category;
            }

            var businessUnitEntityCode = request.BranchFrom;

            if (position.IsBranchRequired) entity.Branch = await FindByCode<Branch>(businessUnitEntityCode);
            else if (position.IsZoneRequired) entity.Zone = await FindByCode<Zone>(businessUnitEntityCode);
            else if (position.IsSubZoneRequired) entity.SubZone = await FindByCode<SubZone>(businessUnitEntityCode);
            else if (position.IsSectorRequired) entity.Sector = await FindByCode<Sector>(businessUnitEntityCode);
            else if (position.IsManagementRequired) entity.Management = await FindByCode<Management>(businessUnitEntityCode);

            _unitOfWork.Repository<User>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
