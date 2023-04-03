using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Threading;
using System.Threading.Tasks;


namespace Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Commands.CreateKmPriceConfiguration
{

    public class CreateKmPriceConfigurationCommandHandler : CommandHandler<CreateKmPriceConfigurationCommand>
    {

        public CreateKmPriceConfigurationCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        public override async Task<Unit> Handle(CreateKmPriceConfigurationCommand request, CancellationToken cancellationToken)
        {
            var entity = new KmPriceConfiguration(request.Price, request.KmPriceType)
            {
                User = await this.GetUserAsync(request.UserId),
                Zone = await this.GetZoneAsync(request.ZoneId),
                SubZone = await this.GetSubZoneAsync(request.SubZoneId),
                StartDate = request.StartDate.HasValue ? request.StartDate : null

            };
            await _unitOfWork.Repository<KmPriceConfiguration>().AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }


        private async Task<Zone> GetZoneAsync(int? zoneId)
        {
            if (!zoneId.HasValue || zoneId == 0) return null;
            var result = await FindById<Zone>(zoneId.Value);
            Guard.Against.Null(result, nameof(zoneId));
            return result;
        }

        private async Task<SubZone> GetSubZoneAsync(int? subZoneId)
        {
            if (!subZoneId.HasValue || subZoneId == 0) return null;
            var result = await FindById<SubZone>(subZoneId.Value);
            Guard.Against.Null(result, nameof(subZoneId));
            return result;
        }

        private async Task<User> GetUserAsync(long? userId)
        {
            if (!userId.HasValue || userId == 0) return null;
            var result = await FindById<User>((int)userId.Value);
            Guard.Against.Null(result, nameof(userId));
            return result;
        }
    }
}
