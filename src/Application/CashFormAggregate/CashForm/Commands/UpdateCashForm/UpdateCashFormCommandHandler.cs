using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Specifications;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormMoney.Dtos;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormMoney.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Commands.UpdateCashForm
{
    public class UpdateCashFormCommandHandler : CommandHandler<UpdateCashFormCommand>
    {


        public UpdateCashFormCommandHandler(
            IAsyncUnitOfWork unitOfWork
            )
            : base(unitOfWork)
        {

        }

        public override async Task<Unit> Handle(UpdateCashFormCommand request, CancellationToken cancellationToken)
        {

            #region Entity
            var currentUser = await this.GetCurrentUserAsync(request.Email);
            var branch = await this.GetBranchAsync(request.BranchId);
            var entity = await FindById<Domain.Entities.CashFormAggregate.CashForm>(request.Id);
            entity.User = currentUser;
            entity.Branch = branch;
            entity.SubTotalCoins = request.SubTotalCoins;
            entity.SubTotalCash = request.SubTotalCash;
            entity.TotalCash = request.TotalCash;
            entity.CreditCardDate = request.CreditCardDate;
            entity.TotalCreditCard = request.TotalCreditCard;
            entity.FundTotal = request.FundTotal;
            entity.Total = request.Total;
            entity.TotalDifference = request.TotalDifference;
            entity.Description = request.Description;
            entity.Period = request.Period;
            entity.TotalPending = request.TotalPending;
            entity.TotalPendingDate = request.TotalPendingDate;
            entity.BalanceTotal = request.BalanceTotal;
            entity.TotalExpense = request.TotalExpense;


            entity.AddCashes(await this.GetCashFormMoneyAsync(request.Cashes, entity.Id));

            #endregion


            _unitOfWork.Repository<Domain.Entities.CashFormAggregate.CashForm>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

        private async Task<Branch> GetBranchAsync(int branchId)
        {
            var result = await FindById<Branch>(branchId);
            Guard.Against.Null(result, nameof(branchId));
            return result;
        }

        #region Cashes

        private async Task RemoveCashesAsync(long cashFormId)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.CashFormAggregate.CashFormMoney>()
                .ListAsync(new MoneyByCashFormSpecification(cashFormId));

            foreach (var item in list)
            {
                _unitOfWork.Repository<Domain.Entities.CashFormAggregate.CashFormMoney>().Delete(item);
            }
            await _unitOfWork.CommitAsync();
        }
        private async Task<List<Domain.Entities.CashFormAggregate.CashFormMoney>> GetCashFormMoneyAsync(Collection<CashFormMoneyDto> cashFormMoneyist, long cashFormId)
        {

            await this.RemoveCashesAsync(cashFormId);
            var result = new List<Domain.Entities.CashFormAggregate.CashFormMoney>();
            foreach (var item in cashFormMoneyist.Where(x => x.Amount > 0))
            {
                var cashForMoney = new Domain.Entities.CashFormAggregate.CashFormMoney
                {
                    Total = item.Total,
                    Amount = item.Amount,
                    MoneyType = await FindById<Domain.Entities.CashFormAggregate.MoneyType>((int)item.Id)
                };
                result.Add(cashForMoney);
            }

            return result;
        }
        #endregion

        #region Expenses
        private async Task<IReadOnlyCollection<Domain.Entities.CashFormAggregate.CashFormExpense>> GetExpensesToPresentateAsync(long userId)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.CashFormAggregate.CashFormExpense>()
                .ListAsync(new CashFormExpenseByUserIdSpecification(userId));

            //Guard.Against.LunchToRenderValid(list);
            return list;
        }
        #endregion

        #region Users

        private async Task<User> GetCurrentUserAsync(string email)
        {
            var users = await _unitOfWork
                 .Repository<User>()
                 .ListAsync(new ByEmployeeEmailSpecification(email));

            Guard.Against.Null(users, nameof(email));
            Guard.Against.IsValidUser(users);

            return users.First();
        }

        #endregion


    }
}
