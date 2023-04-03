using MediatR;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Dtos;
using System;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetCashFormByDate
{
    public class GetCashFormByDateQuery : IRequest<ICollection<CashFormDto>>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
