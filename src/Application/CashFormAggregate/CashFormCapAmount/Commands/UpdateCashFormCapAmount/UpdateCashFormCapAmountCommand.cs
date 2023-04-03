using System;
using MediatR;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Commands.UpdateCashFormCapAmount
{
    public class UpdateCashFormCapAmountCommand : IRequest
    {
        public long Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
