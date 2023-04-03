
using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Specifications;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Guards;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseFormComment.Specifications;
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

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.PathExpenseForm
{
    public class PathExpenseFormCommandHandler : CommandHandler<PathExpenseFormCommand>
    {
        private readonly IDateTime _dateTimeService;
        private readonly IEmailService _emailService;

        public PathExpenseFormCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IDateTime dateTimeService,
            IEmailService emailService)
            : base(unitOfWork)
        {
            _dateTimeService = dateTimeService;
            _emailService = emailService;

        }

        public override async Task<Unit> Handle(PathExpenseFormCommand request, CancellationToken cancellationToken)
        {

            #region Entity
            var currentUser = await GetCurrentUserAsync(request.Email);
            var entity = await FindById<Domain.Entities.ExpenseFormAggregate.ExpenseForm>(request.Id);
            Guard.Against.Null(entity, nameof(request.Id));
            entity.User = currentUser;
            entity.PresentationDate = _dateTimeService.Now;
            entity.Description = request.Description;
            entity.AdministratorUser = await GetNextPositionLevelAsync(currentUser);
            #endregion

            if (entity.IsReset)
            {
                entity.Status = await FindById<ExpenseFormStatus>((int)ExpenseFormStatusEnum.Presentada);
            }

            if (!entity.IsReset)
            {
                entity.Status = entity.PreviousStatus;
            }

            var expenseToRender = await GetExpenseToRenderAsync(request.Id);
            entity.AddExpenses(await FillExpenseToRender(expenseToRender));
            entity.Amount = await SumExpenses(request.Id);

            entity.AddAudit(currentUser, _dateTimeService.Now);

            var commentToRender = await GetCommentToRenderAsync(request.Id);
            entity.AddComments(FillCommentToRender(commentToRender));

            if (entity.AdministratorUser != null) SendEmailToAdmin(entity.AdministratorUser, currentUser);

            _unitOfWork.Repository<Domain.Entities.ExpenseFormAggregate.ExpenseForm>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }



        #region Users
        private async Task<User> GetNextPositionLevelAsync(User currentUser)
        {

            var nextLevelAdmin = currentUser.NextLevelAdmin;
            var codePosition = Enum.GetName(typeof(PositionTypeEnum), nextLevelAdmin);
            var position = await GetPositionAsync(codePosition);

            long? subZoneId = null;
            if (position.IsSubZoneRequired) subZoneId = currentUser.SubZone.Id;

            long? zoneId = null;
            if (position.IsZoneRequired) zoneId = currentUser.Zone.Id;

            long? sectorId = null;
            if (position.IsSectorRequired) sectorId = currentUser.Sector.Id;

            var users = await _unitOfWork
                 .Repository<User>()
                 .ListAsync(new ByEmployeePositionSpecification(position.Name, subZoneId, zoneId, sectorId));

            return !users.Any() ? null : users.First();
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

        private async Task<Position> GetPositionAsync(string code)
        {
            var result = await FindByCode<Position>(code);
            Guard.Against.Null(result, nameof(code));
            return result;
        }
        #endregion

        #region Emails
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
        private async Task<IReadOnlyCollection<Expense>> GetExpenseToRenderAsync(int expenseFormId)
        {
            var result = await _unitOfWork
                      .Repository<Expense>()
                      .ListAsync(new ExpensePendingStatusByIdSpecification(expenseFormId));
            return result;
        }


        private async Task<IReadOnlyCollection<Expense>> GetAllExpenseByExpenseForm(int expenseFormId)
        {
            var result = await _unitOfWork
                      .Repository<Expense>()
                      .ListAsync(new ExpenseByExpenseFormIdSpecification(expenseFormId));
            Guard.Against.ExpenseToRenderValid(result);

            return result;
        }

        private async Task<List<Expense>> FillExpenseToRender(IReadOnlyCollection<Expense> expenseToRender)
        {
            var expenseStatus = await FindById<ExpenseStatus>((int)ExpenseStatusEnum.Presentado);
            foreach (var item in expenseToRender)
            {
                item.Status = expenseStatus;
            }
            return expenseToRender.ToArray().ToList();
        }

        private async Task<decimal?> SumExpenses(int expenseFormId)
        {
            var expensetoSum = await GetAllExpenseByExpenseForm(expenseFormId);
            //mchuquimia no debería sumar TotalAmount y MobilityAmount
            return expensetoSum.Sum(x => x.Amount);// + expensetoSum.Sum(x => x.TotalAmount) + expensetoSum.Sum(x => x.MobilityAmount);
        }
        #endregion

        #region Comments
        private async Task<IReadOnlyCollection<Domain.Entities.ExpenseFormAggregate.ExpenseFormComment>> GetCommentToRenderAsync(int expenseFormId)
        {
            var result = await _unitOfWork
                      .Repository<Domain.Entities.ExpenseFormAggregate.ExpenseFormComment>()
                      .ListAsync(new ExpenseFormCommentByExpenseFormIdSpecification(expenseFormId));

            return result;
        }

        private List<Domain.Entities.ExpenseFormAggregate.ExpenseFormComment> FillCommentToRender(IReadOnlyCollection<Domain.Entities.ExpenseFormAggregate.ExpenseFormComment> commentToRender)
        {

            return commentToRender.ToArray().ToList();
        }
        #endregion
    }
}
