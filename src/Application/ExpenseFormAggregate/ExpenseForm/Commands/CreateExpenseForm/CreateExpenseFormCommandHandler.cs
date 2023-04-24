using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Specifications;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Guards;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Specifications;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;
using Prome.Viaticos.Server.Domain.Entities.ExpenseFormAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using Prome.Viaticos.Server.Domain.Enums;
using Prome.Viaticos.Server.Domain.ValueObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.CreateExpenseForm
{

    public class CreateExpenseFormCommandHandler : CommandHandler<CreateExpenseFormCommand>
    {
        private readonly IDateTime _dateTimeService;
        private readonly IEmailService _emailService;


        public CreateExpenseFormCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IDateTime dateTimeService,
           IEmailService emailService)
            : base(unitOfWork)
        {
            _dateTimeService = dateTimeService;
            _emailService = emailService;
        }

        public override async Task<Unit> Handle(CreateExpenseFormCommand request, CancellationToken cancellationToken)
        {

            #region Entity
            var currentUser = await this.GetCurrentUserAsync(request.Email);
            var expenseToRender = await this.GetExpenseToRenderAsync(currentUser.Id);

            var entity = new Domain.Entities.ExpenseFormAggregate.ExpenseForm
            {
                User = currentUser,
                ExpenseFormNumber = await this.CalculateExpenseFormNumberAsync(currentUser),
                PresentationDate = _dateTimeService.Now,
                Description = request.Description,
                Status = await FindById<ExpenseFormStatus>((int)ExpenseFormStatusEnum.Presentada),
                AdministratorUser = await this.GetNextPositionLevelAsync(currentUser)
            };
            #endregion


            entity.AddExpenses(await this.FillExpenseToRender(expenseToRender));
            entity.Amount = this.SumExpenseToRender(expenseToRender);
            entity.AddAudit(currentUser, _dateTimeService.Now);
            if (!string.IsNullOrEmpty(request.Description))
            {
                entity.AddComment(this.FillCommentToRender(currentUser, request.Description));
            }

            await _unitOfWork.Repository<Domain.Entities.ExpenseFormAggregate.ExpenseForm>().AddAsync(entity);
            await _unitOfWork.CommitAsync();

            if (entity.AdministratorUser != null) this.SendEmailToAdmin(entity.AdministratorUser, currentUser);

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
        private async Task<User> GetNextPositionLevelAsync(User currentUser)
        {

            var nextLevelAdmin = currentUser.NextLevelAdmin;
            string codePosition = Enum.GetName(typeof(PositionTypeEnum), nextLevelAdmin);
            var position = await this.GetPositionAsync(codePosition);

            long? subZoneId = null;
            if (position.IsSubZoneRequired) subZoneId = currentUser.SubZone.Id;

            long? zoneId = null;
            if (position.IsZoneRequired) zoneId = currentUser.Zone.Id;

            long? sectorId = null;
            if (position.IsSectorRequired) sectorId = currentUser.Sector.Id;

            var users = await _unitOfWork
                 .Repository<User>()
                 .ListAsync(new ByEmployeePositionSpecification(position.Code, subZoneId, zoneId, sectorId));

            if (!users.Any()) return null;
            return users.First();
        }

        private async Task<Position> GetPositionAsync(string code)
        {
            var result = await FindByCode<Position>(code);
            Guard.Against.Null(result, nameof(code));
            return result;
        }

        #endregion

        #region Email
        private async void SendEmailToAdmin(User adminUser, User currentUser)
        {
            var email = new Email
            {
                Subject = "Usted tiene una nueva planilla de gastos para autorizar.",
                BodyMessage = $"El usuario {currentUser.Email} presentó una nueva planilla de gastos. "
            };
            email.SendToEmailList.Add(adminUser.Email);
            await _emailService.SendEmailAsync(email);
        }
        #endregion


        #region Expenses
        private async Task<List<Expense>> FillExpenseToRender(IReadOnlyCollection<Expense> expenseToRender)
        {
            var expenseStatus = await FindById<ExpenseStatus>((int)ExpenseStatusEnum.Presentado);
            foreach (var item in expenseToRender)
            {
                item.Status = expenseStatus;
            }
            return expenseToRender.ToList();
        }


        private decimal? SumExpenseToRender(IReadOnlyCollection<Expense> expenseToRender)
        {
            return expenseToRender.Sum(x => x.Amount) + expenseToRender.Sum(x => x.TotalAmount) + expenseToRender.Sum(x => x.MobilityAmount);
        }


        private async Task<string> CalculateExpenseFormNumberAsync(User currentUser)
        {
            return currentUser.EmployeeRecord + " - " + await this.GetNextNumberAsync(currentUser.Id);
        }

        private async Task<int> GetNextNumberAsync(long userId)
        {
            var list = await _unitOfWork
                 .Repository<Domain.Entities.ExpenseFormAggregate.ExpenseForm>()
                 .CountAsync(new ExpenseFormByUserSpecification(userId));
            Guard.Against.Null(list, nameof(Email));
            return list + 1;
        }

        private async Task<IReadOnlyCollection<Expense>> GetExpenseToRenderAsync(long userId)
        {
            var result = await _unitOfWork
                      .Repository<Expense>()
                      .ListAsync(new ExpensePendingStatusByUserSpecification(userId));
            Guard.Against.ExpenseToRenderValid(result);

            return result;
        }
        #endregion

        #region Comments

        private Domain.Entities.ExpenseFormAggregate.ExpenseFormComment FillCommentToRender(User user, string description)
        {

            var comment = new Domain.Entities.ExpenseFormAggregate.ExpenseFormComment(user, description, _dateTimeService.Now);

            return comment;
        }

        #endregion
    }
}
