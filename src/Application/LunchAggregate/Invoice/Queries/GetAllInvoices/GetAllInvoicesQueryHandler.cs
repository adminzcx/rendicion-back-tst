using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.LunchAggregate.Invoice.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Invoice.Queries.GetAllInvoices
{
    public class GetAllInvoicesHandler : QueryHandler<GetAllInvoicesQuery, ICollection<InvoiceDto>>
    {
        public GetAllInvoicesHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<InvoiceDto>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
        {

            var list = await _unitOfWork
             .Repository<Domain.Entities.LunchAggregate.Invoice>()
             .ListAllAsync();


            return Map(list);
        }
    }
}
