using MediatR;
using Prome.Viaticos.Server.Application.DatosMillanAggregate.Dtos;
using System;
using System.Collections.Generic;
using System.Text;



namespace Prome.Viaticos.Server.Application.DatosMillanAggregate.GetAllDatosMillan
{
    public class GetAllDatosMillanQuery : IRequest<ICollection<DatosMillanDto>>
    {
    }
}
