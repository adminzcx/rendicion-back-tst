using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.CuentaCorrienteAggregate;

namespace Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Specifications
{
    public class ByIdSpecification : BaseSpecification<CuentasCorrientes>
    {
        public ByIdSpecification(int id)
            : base(x => x.Id.Equals(id))
        {
        }
    }
}
