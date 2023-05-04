using MediatR;
using Prome.Viaticos.Server.Application.DatosMillanAggregate.Dtos;
using System;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.DatosMillanAggregate.Queries.GetDatosMillanById
{
    public class GetDatosMillanByIdQuery : IRequest<DatosMillanDto>
    {
        public int Id { get; set; }
    }
}


