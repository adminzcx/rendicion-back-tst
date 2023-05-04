using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.CuentaCorrienteAggregate;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;
using System;

namespace Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Dtos
{
    public class CuentasCorrientesByUserDto : IMapFrom<CuentasCorrientes>
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Legajo { get; set; }
        public virtual Reason Reason { get; set; }
        public string Observaciones { get; set; }
        public decimal Monto { get; set; }
        public string CodCalypso { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CuentasCorrientes, CuentasCorrientesByUserDto>()
                .ForMember(dest => dest.Legajo, m => m.MapFrom(source => source.Legajo));
        }
    }
}
