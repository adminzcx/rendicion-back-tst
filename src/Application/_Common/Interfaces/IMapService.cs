using Prome.Viaticos.Server.Domain.ValueObjects.ExpenseAggregate;

namespace Prome.Viaticos.Server.Application.Common.Interfaces
{

    public interface IMapService
    {
        Geolocation GetLatLongByAddress(Map request);

        Geolocation GetCurrentPosition(Map request);
    }
}
