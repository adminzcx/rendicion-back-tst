using Ardalis.GuardClauses;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;
using Prome.Viaticos.Server.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Queries.GetMapByExpense
{

    public class GetMapByExpenseQueryHandler : QueryHandler<GetMapByExpenseQuery, DocumentAttachedDto>
    {

        private readonly IFileService _fileService;

        public GetMapByExpenseQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper,
            IFileService fileService)
            : base(unitOfWork, mapper)
        {

            _fileService = fileService;
        }

        public override async Task<DocumentAttachedDto> Handle(GetMapByExpenseQuery request, CancellationToken cancellationToken)
        {
            var currentExpense = await this.GetCurrentExpenseAsync(request.Id);
            DocumentAttachedDto response = new DocumentAttachedDto
            {
                DocumentAttached = _fileService.DownloadFile(FolderPathEnum.Map, currentExpense.ImageMAP),
                Mime = _fileService.GetMimeType(FolderPathEnum.Map, currentExpense.ImageMAP),
                FileName = currentExpense.ImageMAP
            };
            return response;
        }

        private async Task<Domain.Entities.ExpenseAggregate.Expense> GetCurrentExpenseAsync(int id)
        {
            var result = await _unitOfWork
                 .Repository<Domain.Entities.ExpenseAggregate.Expense>()
                 .GetByIdAsync(id);

            Guard.Against.Null(result, "Gasto");
            Guard.Against.Null(result.ImageMAP, "Mapa");
            return result;
        }
    }
}
