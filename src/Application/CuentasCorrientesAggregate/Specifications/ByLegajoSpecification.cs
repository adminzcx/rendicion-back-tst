using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.CuentaCorrienteAggregate;

namespace Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Specifications
{
    public class ByLegajoSpecification : BaseSpecification<CuentasCorrientes>
    {
        public ByLegajoSpecification(int legajo)
            : base(x => x.Legajo.Equals(legajo))
        {
            AddInclude(t => t.Reason);
        }
    }
}
