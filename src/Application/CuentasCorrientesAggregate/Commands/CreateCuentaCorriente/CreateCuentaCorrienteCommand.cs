using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;


namespace Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Commands.CreateCuentaCorriente
{
    public class CreateCuentaCorrienteCommand : IRequest, IMapFrom<Domain.Entities.CuentaCorrienteAggregate.CuentasCorrientes>
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Legajo { get; set; }
        public int ReasonId { get; set; }
        public string Observaciones { get; set; }
        public decimal Monto { get; set; }
        public string CodCalypso { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCuentaCorrienteCommand, Domain.Entities.CuentaCorrienteAggregate.CuentasCorrientes>();
        }
    }
}
