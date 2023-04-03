
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;
using Prome.Viaticos.Server.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;


namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Commands.PatchExpense
{

    public class PatchExpenseCommandHandler
        : CommandHandler<PatchExpenseCommand>
    {
        public PatchExpenseCommandHandler(
            IAsyncUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async override Task<Unit> Handle(PatchExpenseCommand request, CancellationToken cancellationToken)
        {

            var entity = await FindById<Domain.Entities.ExpenseAggregate.Expense>(request.Id);
            entity.Description = request.Description;

            if (request.ToApprove)
            {
                entity.Status = await FindById<ExpenseStatus>((int)entity.GetApprovalStatusLevel(request.StatusId, (ExpenseFormStatusEnum)entity.ExpenseForm.Status.Id));
            }

            if (request.ToRevert)
            {
                entity.Status = await FindById<ExpenseStatus>((int)entity.GetRejectStatusLevel(request.StatusId, (ExpenseFormStatusEnum)entity.ExpenseForm.Status.Id));
            }

            if (request.ToReject)
            {
                entity.Status = await FindById<ExpenseStatus>((int)ExpenseStatusEnum.Rechazado);
                entity.RevertEnabled = true;
            }

            entity.RejectReason = await this.GetRejectReasonAsync(request.RejectReasonId);

            _unitOfWork.Repository<Domain.Entities.ExpenseAggregate.Expense>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }


        private async Task<Domain.Entities.ExpenseAggregate.RejectReason> GetRejectReasonAsync(int? rejectReasonId)
        {
            if (rejectReasonId > 0)
            {
                return await FindById<Domain.Entities.ExpenseAggregate.RejectReason>((int)rejectReasonId);
            }
            else return null;
        }
    }
}
