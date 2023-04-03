using Ardalis.GuardClauses;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Specifications;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GetExpenseForm
{


    public class GetExpenseFormQueryHandler : QueryHandler<GetExpenseFormQuery, ExpenseFormDto>
    {
        public GetExpenseFormQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ExpenseFormDto> Handle(GetExpenseFormQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
                 .Repository<Domain.Entities.ExpenseFormAggregate.ExpenseForm>()
                 .SingleOrDefaultAsync(new ExpenseFormByIdWithIcludesSpecification(request.Id));
            Guard.Against.Null(entity, nameof(request.Id));

            return Map(entity);
        }

    }
}
