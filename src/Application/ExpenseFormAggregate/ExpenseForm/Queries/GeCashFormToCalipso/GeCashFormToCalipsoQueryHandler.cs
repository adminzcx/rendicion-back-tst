using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Application.AdminAggregate.ExportSearch.Specification;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GeCashFormToCalipso
{

    public class GeCashFormToCalipsoQueryHandler : QueryHandler<GeCashFormToCalipsoQuery, DocumentAttachedDto>
    {
        private new readonly IMapper _mapper;
        private readonly IExpenseFormToCalipsoService _expenseFormToCalipsoService;

        public GeCashFormToCalipsoQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper,
            IExpenseFormToCalipsoService expenseFormToCalipsoService)
            : base(unitOfWork, mapper)
        {
            _mapper = mapper;
            _expenseFormToCalipsoService = expenseFormToCalipsoService;
        }

        public override async Task<DocumentAttachedDto> Handle(GeCashFormToCalipsoQuery request, CancellationToken cancellationToken)
        {
            var list = await GetExpenseFormListAsync(request.StartDate, request.EndDate);

            var response = new DocumentAttachedDto
            {
                DocumentAttached = _expenseFormToCalipsoService.GetExcelFile(list),
                Mime = _expenseFormToCalipsoService.GetMimeType()
            };

            return response;
        }
        private async Task<Collection<ExpenseFormDto>> GetExpenseFormListAsync(DateTime startDate, DateTime endDate)
        {
            var entity = await _unitOfWork
                .Repository<Domain.Entities.ExpenseFormAggregate.ExpenseForm>()
                .ListAsync(new ExpenseFormByExportSearchSpecification(startDate, endDate));

            var result = _mapper.Map<Collection<ExpenseFormDto>>(entity);
            return result;
        }

    }
}
