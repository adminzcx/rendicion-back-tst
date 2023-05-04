using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.DatosMillanAggregate;

namespace Prome.Viaticos.Server.Application.DatosMillanAggregate.Specification
{
    internal class DatosMillanByIdSpecification :BaseSpecification<DatosMillan>
    {
        public DatosMillanByIdSpecification(int id)
           : base(x => x.Id.Equals(id))
        {
        }

    }
}


