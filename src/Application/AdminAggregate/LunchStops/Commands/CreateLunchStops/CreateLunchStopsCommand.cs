using MediatR;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;

namespace Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Commands.CreateLunchStops
{
    public class CreateLunchStopsCommand : IRequest, IMapFrom<Domain.Entities.AdminAggregate.LunchStops>
    {
        public int Id { get; set; }

        public DateTime ValidityStartDate { get; set; }

        public decimal CapAmount { get; set; }

        public Boolean IsMonthly { get; set; }
    }
}
