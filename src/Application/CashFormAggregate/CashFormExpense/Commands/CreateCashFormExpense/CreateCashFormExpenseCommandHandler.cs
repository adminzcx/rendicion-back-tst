using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Guards;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Specifications;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using Prome.Viaticos.Server.Domain.Enums;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Commands.CreateCashFormExpense
{
    public class CreateCashFormExpenseCommandHandler : CommandHandler<CreateCashFormExpenseCommand>
    {
        private readonly IFileService _fileService;
        private readonly IDateTime _dateTimeService;

        public CreateCashFormExpenseCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper,
            IDateTime dateTimeService,
            IFileService fileService)
            : base(unitOfWork, mapper)
        {
            _fileService = fileService;
            _dateTimeService = dateTimeService;
        }

        public override async Task<Unit> Handle(CreateCashFormExpenseCommand request, CancellationToken cancellationToken)
        {
            #region Entity
            var currentUser = await this.GetCurrentUserAsync(request.Email);
            var cashConcept = await this.GetCashConceptAsync(request.CashConceptId);
            var costCenter = await this.GetCostCenterAsync(request.CostCenterId);

            var entity = _mapper.Map<Domain.Entities.CashFormAggregate.CashFormExpense>(request);

            #region CapValidation
            var cap = await this.GetCap(entity.Date);
            Guard.Against.CashFormStopGuardValid(entity.Total, cap);

            #endregion

            entity.CashForm = await this.GetCashFormAsync(request.CashFormId);
            entity.Number = await this.GetNextNumberAsync(currentUser.Id, request.CashFormId);
            entity.User = currentUser;
            entity.CostCenter = costCenter;
            entity.CashConcept = cashConcept;
            entity.DocumentAttached = this.UploadFile(request.UrlFile, request.DocumentAttached);
            #endregion


            await _unitOfWork.Repository<Domain.Entities.CashFormAggregate.CashFormExpense>().AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
        private async Task<int> GetNextNumberAsync(long userId, int cashFormId)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.CashFormAggregate.CashFormExpense>()
                .CountAsync(new CashFormExpenseByUserSpecification(userId, cashFormId));
            Guard.Against.Null(list, nameof(userId));
            return list + 1;
        }
        private async Task<Domain.Entities.CashFormAggregate.CashForm> GetCashFormAsync(int cashformId)
        {
            if (cashformId > 0)
            {
                return await FindById<Domain.Entities.CashFormAggregate.CashForm>(cashformId);
            }
            else return null;
        }
        private async Task<Domain.Entities.CashFormAggregate.CashConcept> GetCashConceptAsync(int cashConceptId)
        {
            var result = await FindById<Domain.Entities.CashFormAggregate.CashConcept>(cashConceptId);
            Guard.Against.Null(result, nameof(cashConceptId));
            return result;
        }

        private async Task<Domain.Entities.CashFormAggregate.CostCenter> GetCostCenterAsync(int costCenterId)
        {
            if (costCenterId == 0) return null;
            var result = await FindById<Domain.Entities.CashFormAggregate.CostCenter>(costCenterId);
            Guard.Against.Null(result, nameof(costCenterId));
            return result;
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

        private string UploadFile(string uRlFile, string documentAttached)
        {
            if (!string.IsNullOrEmpty(uRlFile) && !string.IsNullOrEmpty(documentAttached))
            {
                var customDocumentAttached = _dateTimeService.NowToCustomString + "-" + documentAttached;
                _fileService.UploadFile(FolderPathEnum.Expense, uRlFile, customDocumentAttached);

                return customDocumentAttached;
            }
            else return string.Empty;
        }

        #region Cap

        private async Task<decimal?> GetCap(DateTime date)
        {
            var capAmount = await _unitOfWork
                .Repository<Domain.Entities.CashFormAggregate.CashFormCapAmount>()
                .FirstOrDefaultAsync(new CashFormCapAmountByValidationDateSpecification(date));
            return capAmount?.Amount;
        }

        #endregion
    }
}
