using Ardalis.GuardClauses;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Dtos;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Specifications;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Queries.GetLunchForm
{

    public class GetLunchFormQueryHandler : QueryHandler<GetLunchFormQuery, LunchFormForEditDto>
    {
        public GetLunchFormQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<LunchFormForEditDto> Handle(GetLunchFormQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
                 .Repository<Domain.Entities.LunchFormAggregate.LunchForm>()
                 .SingleOrDefaultAsync(new LunchFormByIdSpecification(request.Id));
            Guard.Against.Null(entity, nameof(request.Id));

            return Map(entity);
        }
    }

}