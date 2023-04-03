using System;
using MediatR;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Commands.DeleteCashFormAmount
{
    public class DeleteCashFormCapAmountCommand : IRequest
    {
        public long Id { get; set; }
    }
}
