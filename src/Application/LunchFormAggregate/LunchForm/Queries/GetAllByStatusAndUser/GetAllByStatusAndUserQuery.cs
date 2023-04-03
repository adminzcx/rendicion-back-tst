using MediatR;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Queries.GetAllByStatusAndUser
{
    public class GetAllByStatusAndUserQuery : IRequest<ICollection<LunchFormForEditDto>>
    {
        public string Email { get; set; }
        public int StatusId { get; set; }
    }
}
