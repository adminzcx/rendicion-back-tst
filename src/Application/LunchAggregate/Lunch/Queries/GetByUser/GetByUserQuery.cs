using MediatR;
using Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Queries
{
    public class GetByUserQuery : IRequest<ICollection<LunchDto>>
    {
        public string Email { get; set; }
    }
}
