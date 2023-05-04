using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Commands.UpdateCuentaCorriente
{
    public class UpdateCuentaCorrienteCommand : IRequest, IMapFrom<Domain.Entities.CuentaCorrienteAggregate.CuentasCorrientes>
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Legajo { get; set; }
        public int ReasonId { get; set; }
        public string Observaciones { get; set; }
        public decimal Monto { get; set; }
        public string CodCalypso { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCuentaCorrienteCommand, Domain.Entities.CuentaCorrienteAggregate.CuentasCorrientes>();
        }
    }
}
