using MediatR;
using Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Dtos;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Queries.GetLunch
{
    public class GetLunchQuery : IRequest<LunchDto>
    {
        public int Id { get; set; }
    }
}
