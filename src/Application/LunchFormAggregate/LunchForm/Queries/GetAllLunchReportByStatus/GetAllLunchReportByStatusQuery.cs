using MediatR;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Queries.GetAllLunchReportByStatus
{
    public class GetAllLunchReportByStatusQuery : IRequest<ICollection<LunchFormReportDto>>
    {
        public string Email { get; set; }
        public int StatusId { get; set; }
    }
}
