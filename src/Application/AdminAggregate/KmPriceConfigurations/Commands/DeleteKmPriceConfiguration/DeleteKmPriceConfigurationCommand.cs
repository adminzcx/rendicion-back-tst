using MediatR;

namespace Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Commands.DeleteKmPriceConfiguration
{
    public class DeleteKmPriceConfigurationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
