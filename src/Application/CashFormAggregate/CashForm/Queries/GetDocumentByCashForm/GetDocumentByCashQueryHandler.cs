using Ardalis.GuardClauses;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Dtos;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using Prome.Viaticos.Server.Domain.Enums;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetDocumentByCashForm
{

    public class GetDocumentByCashQueryHandler : QueryHandler<GetDocumentByCashFormQuery, DocumentAttachedDto>
    {
        private new readonly IMapper _mapper;
        private readonly IReportService _reportService;
        private readonly IDateTime _dateTimeService;

        public GetDocumentByCashQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper,
            IReportService reportService,
            IDateTime dateTimeService)
            : base(unitOfWork, mapper)
        {
            _mapper = mapper;
            _reportService = reportService;
            _dateTimeService = dateTimeService;
        }

        public override async Task<DocumentAttachedDto> Handle(GetDocumentByCashFormQuery request, CancellationToken cancellationToken)
        {
            var currentCashForm = await this.GetCurrentCashFormAsync(request.Id);
            var currentUser = await this.GetCurrentUserAsync(request.Email);
            var response = new DocumentAttachedDto
            {
                DocumentAttached = _reportService.GenerateCashReport(FolderPathEnum.Report, currentCashForm),
                Mime = _reportService.GetMimeType()
            };

            #region Audits
            var entity = await GetCashFormAsync(request.Id);
            entity.AddAudit(currentUser, _dateTimeService.Now, "Impresión");
            _unitOfWork.Repository<Domain.Entities.CashFormAggregate.CashForm>().Update(entity);
            await _unitOfWork.CommitAsync();
            #endregion

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

        private async Task<Domain.Entities.CashFormAggregate.CashForm> GetCashFormAsync(int id)
        {
            return await _unitOfWork
                .Repository<Domain.Entities.CashFormAggregate.CashForm>()
                .SingleOrDefaultAsync(new CashFormByIdSpecification(id));
        }
        private async Task<User> GetCurrentUserAsync(string email)
        {
            var users = await _unitOfWork
                .Repository<User>()
                .ListAsync(new ByEmployeeEmailSpecification(email));

            Guard.Against.Null(users, nameof(email));
            Guard.Against.IsValidUser(users);

            return users.First();
        }

    }
}
