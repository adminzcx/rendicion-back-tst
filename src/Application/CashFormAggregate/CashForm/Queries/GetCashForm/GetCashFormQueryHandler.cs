using Ardalis.GuardClauses;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Dtos;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetCashForm
{

    public class GetCashFormQueryHandler : QueryHandler<GetCashFormQuery, CashFormDto>
    {
        public GetCashFormQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<CashFormDto> Handle(GetCashFormQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
                 .Repository<Domain.Entities.CashFormAggregate.CashForm>()
                 .SingleOrDefaultAsync(new CashFormByIdSpecification(request.Id));
            Guard.Against.Null(entity, nameof(request.Id));

            return Map(entity);
        }
    }

}