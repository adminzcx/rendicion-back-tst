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


namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Commands.PatchUser
{

    public class PatchUserCommandHandler
        : CommandHandler<PatchUserCommand>
    {
        public PatchUserCommandHandler(
            IAsyncUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async override Task<Unit> Handle(PatchUserCommand request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork
                .Repository<User>()
                .ListAsync(new ByEmployeeRecordWithIncludesSpecification(request.EmployeeRecord));
            Guard.Against.Null(entities, nameof(request.EmployeeRecord));
            Guard.Against.UniqueUser(entities);

            var entity = entities.First();

            if (!string.IsNullOrEmpty(request.BranchFrom))
            {
                var branchFrom = await FindByCode<Branch>(request.BranchFrom);
                Guard.Against.Null(branchFrom, nameof(request.BranchFrom));
                entity.Branch = branchFrom;
            }

            var position = entity.Position;

            if (!string.IsNullOrEmpty(request.Position))
            {
                position = await FindByCode<Position>(request.Position);
                Guard.Against.Null(position, nameof(request.Position));
                entity.Position = position;
            }

            entity.FirstName = string.IsNullOrEmpty(request.FirstName) ? entity.FirstName : request.FirstName;
            entity.LastName = string.IsNullOrEmpty(request.LastName) ? entity.LastName : request.LastName;
            entity.Email = string.IsNullOrEmpty(request.Email) ? entity.Email : request.Email;
            entity.IsAdministrator = request.IsAdministrator ?? entity.IsAdministrator;
            entity.Cuit = request.Cuit;

            entity.Clean();

            if (request.Category != null)
            {
                var category = await FindByCode<Category>(request.Category);
                Guard.Against.Null(category, nameof(request.Category));
                entity.Category = category;
            }

            if (!string.IsNullOrEmpty(request.BusinessUnit))
            {
                var businessUnitEntityCode = request.BusinessUnit;

                if (position.IsBranchRequired) entity.Branch = await FindByCode<Branch>(businessUnitEntityCode);
                else if (position.IsZoneRequired) entity.Zone = await FindByCode<Zone>(businessUnitEntityCode);
                else if (position.IsSubZoneRequired) entity.SubZone = await FindByCode<SubZone>(businessUnitEntityCode);
                else if (position.IsSectorRequired) entity.Sector = await FindByCode<Sector>(businessUnitEntityCode);
                else if (position.IsManagementRequired) entity.Management = await FindByCode<Management>(businessUnitEntityCode);
            }

            _unitOfWork.Repository<User>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
