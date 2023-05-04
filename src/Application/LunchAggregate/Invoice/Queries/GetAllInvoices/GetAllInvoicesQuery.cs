using MediatR;
using Prome.Viaticos.Server.Application.LunchAggregate.Invoice.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Invoice.Queries.GetAllInvoices
{
    public class GetAllInvoicesQuery : IRequest<ICollection<InvoiceDto>>
    {
    }
}
