using MediatR;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prome.Viaticos.Server.Application.YPFRutaAggregate.Commands.UpdateDataYPF
{
    public class UpdateDataYPFCommand : IRequest, IMapFrom<Domain.Entities.YPFRutaAggregate.Datos_YPF>
    {
        public string FileNameBase64 { get; set; }
        public string FileResultBase64 { get; set; }
    }
}
