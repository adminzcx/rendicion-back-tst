using Ardalis.GuardClauses;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Specifications;
using Prome.Viaticos.Server.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GetDocumentByExpenseForm
{

    public class GetDocumentByExpenseFormQueryHandler : QueryHandler<GetDocumentByExpenseFormQuery, DocumentAttachedDto>
    {
        private new readonly IMapper _mapper;
        private readonly IReportService _reportService;

        public GetDocumentByExpenseFormQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper,
            IReportService reportService)
            : base(unitOfWork, mapper)
        {
            _mapper = mapper;
            _reportService = reportService;
        }

        public override async Task<DocumentAttachedDto> Handle(GetDocumentByExpenseFormQuery request, CancellationToken cancellationToken)
        {
            var currentExpense = await this.GetCurrentExpenseFormAsync(request.Id);
            var response = new DocumentAttachedDto
            {
                DocumentAttached = _reportService.GenerateExpenseReport(FolderPathEnum.Report, currentExpense),
                Mime = _reportService.GetMimeType()
            };
            return response;
        }


        private async Task<ExpenseFormDto> GetCurrentExpenseFormAsync(int id)
        {
            var entity = await _unitOfWork
                .Repository<Domain.Entities.ExpenseFormAggregate.ExpenseForm>()
                .SingleOrDefaultAsync(new ExpenseFormByIdWithIcludesSpecification(id));
            Guard.Against.Null(entity, nameof(id));

            var result = _mapper.Map<ExpenseFormDto>(entity);
            return result;
        }
    }
}
