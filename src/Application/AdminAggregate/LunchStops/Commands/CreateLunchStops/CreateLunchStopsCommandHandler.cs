using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Commands.CreateLunchStops
{
    public class CreateLunchStopsCommandHandler : CommandHandler<CreateLunchStopsCommand>
    {
        public CreateLunchStopsCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper
            )
            : base(unitOfWork, mapper)
        {

        }

        public override async Task<Unit> Handle(CreateLunchStopsCommand request, CancellationToken cancellationToken)
        {
            // var entity = _mapper.Map<Domain.Entities.AdminAggregate.LunchStops>(request);

            var entity = new Domain.Entities.AdminAggregate.LunchStops(request.CapAmount, request.ValidityStartDate, request.IsMonthly);

            await _unitOfWork.Repository<Domain.Entities.AdminAggregate.LunchStops>().AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
