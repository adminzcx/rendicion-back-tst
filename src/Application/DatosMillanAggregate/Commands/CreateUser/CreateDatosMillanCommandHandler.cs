using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.DatosMillanAggregate.Guards;
using Prome.Viaticos.Server.Application.DatosMillanAggregate.Specification;
using Prome.Viaticos.Server.Domain.Entities.DatosMillanAggregate;
using System.Threading;
using System.Threading.Tasks;


namespace Prome.Viaticos.Server.Application.DatosMillanAggregate.Commands.CreateUser
{
    public class CreateDatosMillanCommandHandler : CommandHandler<CreateDatosMillanCommand>
    {
        public CreateDatosMillanCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper 
            )
            : base(unitOfWork, mapper)
        { }

        public override async Task<Unit> Handle(CreateDatosMillanCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DatosMillan>(request);
            entity.DisabledDate = null;
            entity.Created = new System.DateTime();

            entity.DisabledDate = null;
            entity.Created = new System.DateTime();

            await _unitOfWork.Repository<DatosMillan>().AddAsync(entity);
           await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

    }
}
