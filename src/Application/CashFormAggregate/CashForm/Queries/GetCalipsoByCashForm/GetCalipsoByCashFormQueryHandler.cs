using Ardalis.GuardClauses;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Dtos;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetCalipsoByCashForm
{

    public class GetCalipsoByCashFormQueryHandler : QueryHandler<GetCalipsoByCashFormQuery, DocumentAttachedDto>
    {
        private new readonly IMapper _mapper;
        private readonly ICashFormToCalipsoService _cashFormToCalipsoService;

        public GetCalipsoByCashFormQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper,
            ICashFormToCalipsoService cashFormToCalipsoService)
            : base(unitOfWork, mapper)
        {
            _mapper = mapper;
            _cashFormToCalipsoService = cashFormToCalipsoService;
        }

        public override async Task<DocumentAttachedDto> Handle(GetCalipsoByCashFormQuery request, CancellationToken cancellationToken)
        {
            var currentCashForm = await this.GetCurrentCashFormAsync(request.Id);
            var response = new DocumentAttachedDto
            {
                DocumentAttached = _cashFormToCalipsoService.GetExcelFile(currentCashForm),
                Mime = _cashFormToCalipsoService.GetMimeType()
            };

            return response;
        }


        private async Task<CashFormDto> GetCurrentCashFormAsync(int id)
        {
            var entity = await _unitOfWork
                .Repository<Domain.Entities.CashFormAggregate.CashForm>()
                .SingleOrDefaultAsync(new CashFormByIdSpecification(id));
            Guard.Against.Null(entity, nameof(id));

            var result = _mapper.Map<CashFormDto>(entity);
            return result;
        }

    }
}
