
using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Threading;
using System.Threading.Tasks;


namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Commands.CreateUser
{


    public class CreateUserCommandHandler : CommandHandler<CreateUserCommand>
    {
        public CreateUserCommandHandler(
            IAsyncUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

        public override async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork
               .Repository<User>()
               .ListAsync(new ByEmployeeRecordSpecification(request.EmployeeRecord));
            Guard.Against.Null(entities, nameof(request.EmployeeRecord));
            Guard.Against.IsExistEmployeeRecord(entities);

            var branchFrom = await FindByCode<Branch>(request.BranchFrom);
            Guard.Against.Null(branchFrom, nameof(request.BranchFrom));

            var position = await FindByCode<Position>(request.Position);
            Guard.Against.Null(position, nameof(request.Position));

            var entity = new User(
                request.FirstName,
                request.LastName,
                request.Email,
                request.EmployeeRecord,
                request.IsAdministrator,
                branchFrom,
                position,
                request.Cuit,
                request.TarjetaYPF,
                request.YPFRuta);

            if (!string.IsNullOrEmpty(request.Category))
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

            await _unitOfWork.Repository<User>().AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
