using Ardalis.GuardClauses;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;
using Prome.Viaticos.Server.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Queries.GetDocumentByCashFormExpense
{

    public class GetDocumentByCashFormExpenseQueryHandler : QueryHandler<GetDocumentByCashFormExpenseQuery, DocumentAttachedDto>
    {

        private readonly IFileService _fileService;

        public GetDocumentByCashFormExpenseQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper,
            IFileService fileService)
            : base(unitOfWork, mapper)
        {
            _fileService = fileService;
        }

        public override async Task<DocumentAttachedDto> Handle(GetDocumentByCashFormExpenseQuery request, CancellationToken cancellationToken)
        {
            var currentExpense = await this.GetCurrentExpenseAsync(request.Id);
            DocumentAttachedDto response = new DocumentAttachedDto
            {
                DocumentAttached =
                    _fileService.DownloadFile(FolderPathEnum.Expense, currentExpense.DocumentAttached),
                Mime = _fileService.GetMimeType(FolderPathEnum.Expense, currentExpense.DocumentAttached),
                FileName = currentExpense.DocumentAttached
            };
            return response;
        }


        private async Task<Domain.Entities.CashFormAggregate.CashFormExpense> GetCurrentExpenseAsync(int id)
        {
            var result = await _unitOfWork
                 .Repository<Domain.Entities.CashFormAggregate.CashFormExpense>()
                 .GetByIdAsync(id);

            Guard.Against.Null(result, "Gasto");
            Guard.Against.Null(result.DocumentAttached, "Archivo Adjunto");
            return result;
        }
    }
}
