using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.YPFRutaAggregate;

namespace Prome.Viaticos.Server.Application.YPFRutaAggregate.Specifications
{
    public class ByIdSpecification : BaseSpecification<Datos_YPF>
    {
        public ByIdSpecification(int id)
            : base(x => x.Id.Equals(id))
        {
        }
    }
}
