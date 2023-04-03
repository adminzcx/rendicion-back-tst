using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Specifications;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.PathExpenseFormAdvices
{
    public class PathExpenseFormAdvicesCommandHandler : CommandHandler<PathExpenseFormAdvicesCommand>
    {


        public PathExpenseFormAdvicesCommandHandler(
            IAsyncUnitOfWork unitOfWork
           )
            : base(unitOfWork)
        {



        }

        public override async Task<Unit> Handle(PathExpenseFormAdvicesCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await this.GetCurrentUserAsync(request.Email);

            var list = await this.GetAllExpenseByExpenseForm(request.Id);
            var expenseToRender = await this.GetExpenseToRenderAsync(currentUser.Id);

            list.AddRange(expenseToRender);

            foreach (var entity in list)
            {
                var expenseStopList = await this.GetExpenseStopsAsync(entity.Concept.Id);
                var expenseList = await this.GetExpensesAsync(entity.User.Id, entity.ExpenseDate, entity.Id);
                this.RemoveAdvicesAsync(entity);
                entity.GenerateAdvices(expenseStopList, expenseList);
                _unitOfWork.Repository<Expense>().Update(entity);
            }

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }


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

        #region Advices
        private async Task<IEnumerable<ExpenseStops>> GetExpenseStopsAsync(long conceptId)
        {
            return (IEnumerable<ExpenseStops>)await _unitOfWork
                .Repository<ExpenseStops>()
                .ListAsync(new ExpenseStopByConceptSpecification(conceptId));
        }

        private async Task<IEnumerable<Expense>> GetExpensesAsync(long userId, DateTime date, long expenseId)
        {
            return (IEnumerable<Expense>)await _unitOfWork
                .Repository<Expense>()
                .ListAsync(new ExpenseByConceptAndUserSpecification(userId, date, expenseId));
        }
        private void RemoveAdvicesAsync(Expense entity)
        {

            foreach (var item in entity.Advices)
            {
                _unitOfWork.Repository<ExpenseAdvice>().Delete(item);
            }
        }
        #endregion

        #region Expenses
        private async Task<List<Expense>> GetAllExpenseByExpenseForm(int expenseFormId)
        {
            var result = await _unitOfWork
                .Repository<Expense>()
                .ListAsync(new ExpenseByExpenseFormIdSpecification(expenseFormId));
            return (List<Expense>)result;
        }

        private async Task<IEnumerable<Expense>> GetExpenseToRenderAsync(long userId)
        {
            var result = await _unitOfWork
                .Repository<Expense>()
                .ListAsync(new ExpensePendingStatusByUserSpecification(userId));
            return (IEnumerable<Expense>)result;
        }
    }
    #endregion

}

