using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.YPFRutaAggregate.Commands.CreateYPFRuta
{
    public class CreateYPFRutaCommandHandler : CommandHandler<CreateYPFRutaCommand>
    {
        public CreateYPFRutaCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper
           )
            : base(unitOfWork, mapper)
        {

        }
        public override async Task<Unit> Handle(CreateYPFRutaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.YPFRutaAggregate.Datos_YPF>(request);

            await _unitOfWork.Repository<Domain.Entities.YPFRutaAggregate.Datos_YPF>().AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
