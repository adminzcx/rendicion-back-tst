using MediatR;
using System;

namespace Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Commands.UpdateExpenseStops
{
    public class UpdateExpenseStopsCommand : IRequest
    {
        public int Id { get; set; }
        public int ReasonId { get; set; }

        public int ConceptId { get; set; }

        public DateTime ValidityStartDate { get; set; }

        public decimal CapAmount { get; set; }
    }
}
