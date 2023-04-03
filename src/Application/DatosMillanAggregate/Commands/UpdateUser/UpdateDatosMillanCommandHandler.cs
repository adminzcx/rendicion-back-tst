using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.Entities.DatosMillanAggregate;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.DatosMillanAggregate.Commands.UpdateUser
{
    public class UpdateDatosMillanCommandHandler : CommandHandler<UpdateDatosMillanCommand>
    {
        public UpdateDatosMillanCommandHandler(
           IAsyncUnitOfWork unitOfWork)
           : base(unitOfWork)
        { }

        public async override Task<Unit> Handle(UpdateDatosMillanCommand request, CancellationToken cancellationToken)
        {
            var entity = await FindById<DatosMillan>(request.Id);

         
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Email = request.Email;
            entity.IsAdministrator = request.IsAdministrator;
            entity.EmployeeRecord = request.EmployeeRecord;
            //entity.Position = position;
            entity.Cuit = request.Cuit;         
            //entity.Clean();

         


            _unitOfWork.Repository<DatosMillan>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}







