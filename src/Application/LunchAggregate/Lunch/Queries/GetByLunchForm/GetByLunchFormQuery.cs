using MediatR;
using Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Queries.GetByLunchForm
{
    public class GetByLunchFormQuery : IRequest<ICollection<LunchDto>>
    {
        public string Email { get; set; }

        public int LunchFormId { get; set; }
    }
}
