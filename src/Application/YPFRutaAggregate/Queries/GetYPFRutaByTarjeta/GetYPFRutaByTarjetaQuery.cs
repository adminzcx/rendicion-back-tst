using MediatR;
using Prome.Viaticos.Server.Application.YPFRutaAggregate.Dtos;

namespace Prome.Viaticos.Server.Application.YPFRutaAggregate.Queries.GetYPFRutaByTarjeta
{
    public class GetYPFRutaByTarjetaQuery : IRequest<YPFRutaDto>
    {
        public string Identificacion_Tarjeta { get; set; }
    }
}
