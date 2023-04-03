using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Specifications;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Specifications;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormMoney.Dtos;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.CashFormAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using Prome.Viaticos.Server.Domain.Enums;
using Prome.Viaticos.Server.Domain.ValueObjects.Common;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Commands.CreateCashForm
{
    public class CreateCashFormCommandHandler : CommandHandler<CreateCashFormCommand>
    {
        private readonly IDateTime _dateTimeService;

        public CreateCashFormCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IDateTime dateTimeService,
            IMapper mapper)
            : base(unitOfWork, mapper)
        {
            _dateTimeService = dateTimeService;
        }

        public override async Task<Unit> Handle(CreateCashFormCommand request, CancellationToken cancellationToken)
        {
            #region Entity
            var currentUser = await this.GetCurrentUserAsync(request.Email);
            var branch = await this.GetBranchAsync(request.BranchId);
            var organism = await this.GetOrganismAsync(request.OrganismId);
            var status = await FindById<CashFormStatus>((int)CashFormStatusEnum.Borrador);
            var entity = _mapper.Map<Domain.Entities.CashFormAggregate.CashForm>(request);

            entity.User = currentUser;
            entity.Branch = branch;
            entity.Status = status;
            entity.Organism = organism;
            entity.PresentationDate = _dateTimeService.Now;
            entity.CashFormNumber = await this.CalculateCashFormNumberAsync(currentUser);
            entity.AddCashes(await this.GetCashFormMoneyAsync(request.Cashes));
            entity.AddExpenses(await this.GetCashFormExpensesAsync(currentUser));
            #endregion

            entity.AddAudit(currentUser, _dateTimeService.Now);
            if (!string.IsNullOrEmpty(request.Description))
            {
                entity.AddComment(this.FillCommentToRender(currentUser, request.Description));
            }

            await _unitOfWork.Repository<Domain.Entities.CashFormAggregate.CashForm>().AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

        private async Task<List<Domain.Entities.CashFormAggregate.CashFormMoney>> GetCashFormMoneyAsync(Collection<CashFormMoneyDto> cashFormMoneyist)
        {
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

        private async Task<List<Domain.Entities.CashFormAggregate.CashFormExpense>> GetCashFormExpensesAsync(User currentUser)
        {
            var list = await _unitOfWork
                 .Repository<Domain.Entities.CashFormAggregate.CashFormExpense>()
                 .ListAsync(new ExpenseByCashFormSpecification(0, currentUser.Id));

            return (List<Domain.Entities.CashFormAggregate.CashFormExpense>)list;
        }
        private async Task<string> CalculateCashFormNumberAsync(User currentUser)
        {
            return currentUser.EmployeeRecord + " - " + await this.GetNextNumberAsync(currentUser.Id);
        }

        private async Task<int> GetNextNumberAsync(long userId)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.CashFormAggregate.CashForm>()
                .CountAsync(new CashFormByUserSpecification(userId));
            Guard.Against.Null(list, nameof(Email));
            return list + 1;
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

        private async Task<Branch> GetBranchAsync(int branchId)
        {
            var result = await FindById<Branch>(branchId);
            Guard.Against.Null(result, nameof(branchId));
            return result;
        }

        private async Task<Domain.Entities.CashFormAggregate.Organism> GetOrganismAsync(int organismId)
        {
            var result = await FindById<Domain.Entities.CashFormAggregate.Organism>(organismId);
            Guard.Against.Null(result, nameof(organismId));
            return result;
        }

        #region Comments

        private Domain.Entities.CashFormAggregate.CashFormComment FillCommentToRender(User user, string description)
        {
            var comment = new Domain.Entities.CashFormAggregate.CashFormComment(user, description, _dateTimeService.Now);
            return comment;
        }

        #endregion
    }
}
