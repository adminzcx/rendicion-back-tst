using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Dtos;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetCashFormByDate
{
    public class GetCashFormByDateQueryHandler : QueryHandler<GetCashFormByDateQuery, ICollection<CashFormDto>>
    {
        public GetCashFormByDateQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper
        )
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<CashFormDto>> Handle(GetCashFormByDateQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyCollection<Domain.Entities.CashFormAggregate.CashForm> list;

            if(request.StartDate == request.EndDate)
            {

                 list = await _unitOfWork
                    .Repository<Domain.Entities.CashFormAggregate.CashForm>()
                    .ListAsync(new CashFormByExactExportSearchSpecification(request.StartDate));

            }
            else
            {
                 list = await _unitOfWork
                    .Repository<Domain.Entities.CashFormAggregate.CashForm>()
                    .ListAsync(new CashFormByExportSearchSpecification(request.StartDate, request.EndDate));
            }

            return Map(list);
        }
    }
}
