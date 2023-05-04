using MediatR;
using System.Collections.Generic;
using Prome.Viaticos.Server.Application.YPFRutaAggregate.Dtos;

namespace Prome.Viaticos.Server.Application.YPFRutaAggregate.Queries.GetAllYPF
{
    public class GetAllYPFQuery : IRequest<ICollection<YPFRutaDto>>
    {
    }
}
