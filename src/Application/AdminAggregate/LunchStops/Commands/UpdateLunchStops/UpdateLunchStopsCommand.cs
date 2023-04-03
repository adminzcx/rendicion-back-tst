using MediatR;
using System;

namespace Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Commands.UpdateLunchStops
{
    public class UpdateLunchStopsCommand : IRequest
    {
        public int Id { get; set; }

        public DateTime ValidityStartDate { get; set; }

        public decimal CapAmount { get; set; }

        public Boolean IsMonthly { get; set; }

    }
}
