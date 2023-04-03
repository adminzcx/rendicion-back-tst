using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Threading;
using System.Threading.Tasks;


namespace Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Commands.UpdateKmPriceConfiguration
{


    public class UpdateKmPriceConfigurationCommandHandler : CommandHandler<UpdateKmPriceConfigurationCommand>
    {

        public UpdateKmPriceConfigurationCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        public override async Task<Unit> Handle(UpdateKmPriceConfigurationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
                .Repository<KmPriceConfiguration>()
                .GetByIdAsync(request.Id);

            entity.StartDate = request.StartDate;
            entity.Price = request.Price;
            entity.User = await this.GetUserAsync(request.UserId);
            entity.Zone = await this.GetZoneAsync(request.ZoneId);
            entity.SubZone = await this.GetSubZoneAsync(request.SubZoneId);
            await _unitOfWork.Repository<KmPriceConfiguration>().AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }


        private async Task<Zone> GetZoneAsync(int? zoneId)
        {
            if (!zoneId.HasValue) return null;
            var result = await FindById<Zone>(zoneId.Value);
            Guard.Against.Null(result, nameof(zoneId));
            return result;
        }

        private async Task<SubZone> GetSubZoneAsync(int? subZoneId)
        {
            if (!subZoneId.HasValue) return null;
            var result = await FindById<SubZone>(subZoneId.Value);
            Guard.Against.Null(result, nameof(subZoneId));
            return result;
        }

        private async Task<User> GetUserAsync(long? userId)
        {
            if (!userId.HasValue) return null;
            var result = await FindById<User>((int)userId.Value);
            Guard.Against.Null(result, nameof(userId));
            return result;
        }
    }
}
