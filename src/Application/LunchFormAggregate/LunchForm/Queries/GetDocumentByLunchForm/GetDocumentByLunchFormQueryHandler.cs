using Ardalis.GuardClauses;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Dtos;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Specifications;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using Prome.Viaticos.Server.Domain.Enums;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Queries.GetDocumentByLunchForm
{

    public class GetDocumentByLunchFormQueryHandler : QueryHandler<GetDocumentByLunchFormQuery, DocumentAttachedDto>
    {
        private new readonly IMapper _mapper;
        private readonly IReportService _reportService;
        private readonly IDateTime _dateTimeService;

        public GetDocumentByLunchFormQueryHandler(
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

        public override async Task<DocumentAttachedDto> Handle(GetDocumentByLunchFormQuery request, CancellationToken cancellationToken)
        {
            var currentLunch = await this.GetCurrentExpenseFormAsync(request.Id);
            var currentUser = await this.GetCurrentUserAsync(request.Email);

            var response = new DocumentAttachedDto
            {
                DocumentAttached = _reportService.GenerateLunchReport(FolderPathEnum.Report, currentLunch),
                Mime = _reportService.GetMimeType()
            };

            #region Audits
            var entity = await GetCurrentLunchFormAsync(request.Id);
            entity.AddAudit(currentUser, _dateTimeService.Now, "Impresión");
            _unitOfWork.Repository<Domain.Entities.LunchFormAggregate.LunchForm>().Update(entity);
            await _unitOfWork.CommitAsync();
            #endregion



            return response;
        }


        private async Task<LunchFormForEditDto> GetCurrentExpenseFormAsync(int id)
        {
            var entity = await _unitOfWork
                .Repository<Domain.Entities.LunchFormAggregate.LunchForm>()
                .SingleOrDefaultAsync(new LunchFormByIdSpecification(id));
            Guard.Against.Null(entity, nameof(id));

            var result = _mapper.Map<LunchFormForEditDto>(entity);
            return result;
        }

        private async Task<Domain.Entities.LunchFormAggregate.LunchForm> GetCurrentLunchFormAsync(int id)
        {
            var entity = await _unitOfWork
                .Repository<Domain.Entities.LunchFormAggregate.LunchForm>()
                .SingleOrDefaultAsync(new LunchFormByIdSpecification(id));
            Guard.Against.Null(entity, nameof(id));

            return entity;
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
