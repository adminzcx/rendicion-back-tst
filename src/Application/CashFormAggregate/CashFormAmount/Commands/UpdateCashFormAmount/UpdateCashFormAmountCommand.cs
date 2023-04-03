using MediatR;
using System;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Commands.UpdateCashFormAmount
{
    public class UpdateCashFormAmountCommand : IRequest
    {
        public long Id { get; set; }

        public int BranchId { get; set; }

        public decimal Amount { get; set; }

        public DateTime StartDate { get; set; }
    }
}
