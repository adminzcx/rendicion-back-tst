using MediatR;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Dtos;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Queries.GetLunchForm
{
    public class GetLunchFormQuery : IRequest<LunchFormForEditDto>
    {
        public int Id { get; set; }
    }
}
