using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.YPFRutaAggregate;

namespace Prome.Viaticos.Server.Application.YPFRutaAggregate.Specifications
{
    public class ByTarjetaSpecification : BaseSpecification<Datos_YPF>
    {
        public ByTarjetaSpecification(string tarjeta)
            : base(x => x.Tarjeta == tarjeta)
        {
        }
    }
}
