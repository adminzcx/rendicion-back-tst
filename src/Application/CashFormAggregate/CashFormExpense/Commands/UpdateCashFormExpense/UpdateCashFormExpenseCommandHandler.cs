using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Guards;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Specifications;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.Enums;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Commands.UpdateCashFormExpense
{
    public class UpdateCashFormExpenseCommandHandler : CommandHandler<UpdateCashFormExpenseCommand>
    {
        private readonly IFileService _fileService;
        private readonly IDateTime _dateTimeService;

        public UpdateCashFormExpenseCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IDateTime dateTimeService,
            IFileService fileService,
            IMapper mapper)
            : base(unitOfWork, mapper)
        {
            _fileService = fileService;
            _dateTimeService = dateTimeService;
        }

        public override async Task<Unit> Handle(UpdateCashFormExpenseCommand request, CancellationToken cancellationToken)
        {
            #region Entity
            var entity = await FindById<Domain.Entities.CashFormAggregate.CashFormExpense>(request.Id);
            var cashConcept = await this.GetCashConceptAsync(request.CashConceptId);
            var costCenter = await this.GetCostCenterAsync(request.CostCenterId);

            #region CapValidation
            var cap = await this.GetCap(entity.Date);
            Guard.Against.CashFormStopGuardValid(request.Total, cap);
            #endregion

            entity.Vendor = request.Vendor;
            entity.Total = request.Total;
            entity.Date = request.Date;
            entity.CostCenter = costCenter;
            entity.CashConcept = cashConcept;
            entity.DocumentAttached = this.UploadFile(request.UrlFile, request.DocumentAttached);
            #endregion

            _unitOfWork.Repository<Domain.Entities.CashFormAggregate.CashFormExpense>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
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

