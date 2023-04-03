using MediatR;
using Prome.Viaticos.Server.Application.YPFRutaAggregate.Dtos;
using System;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.YPFRutaAggregate.Queries.GetYPFRutaById
{
    public class GetYPFRutaByIdQuery : IRequest<YPFRutaDto>
    {
        public int Id { get; set; }
    }
}
