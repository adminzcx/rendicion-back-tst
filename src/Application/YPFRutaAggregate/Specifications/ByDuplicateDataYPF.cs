using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.YPFRutaAggregate;
using System;

namespace Prome.Viaticos.Server.Application.YPFRutaAggregate.Specifications
{
    public class ByDuplicateDataYPF : BaseSpecification<Datos_YPF>
    {
        public ByDuplicateDataYPF(string tarjeta, DateTime fecha, decimal litros)
            : base(x => x.Tarjeta == tarjeta && x.Fecha == fecha && x.Litros_Unidades == litros)
        {
        }
    }
}
