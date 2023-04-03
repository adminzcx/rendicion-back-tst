using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Specifications;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormMoney.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using Prome.Viaticos.Server.Domain.Enums;
using Prome.Viaticos.Server.Domain.ValueObjects.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Commands.PathCashFormStatus
{
    public class PathCashFormStatusCommandHandler : CommandHandler<PathCashFormStatusCommand>
    {
        private readonly IEmailService _emailService;
        private readonly IDateTime _dateTimeService;

        public PathCashFormStatusCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IDateTime dateTimeService,
            IEmailService emailService)
            : base(unitOfWork)
        {
            _emailService = emailService;
            _dateTimeService = dateTimeService;
        }

        public override async Task<Unit> Handle(PathCashFormStatusCommand request, CancellationToken cancellationToken)
        {

            #region Entity
            var currentUser = await this.GetCurrentUserAsync(request.Email);

            var entity = await FindById<Domain.Entities.CashFormAggregate.CashForm>(request.Id);

            if (entity.PreviousStatus is null && entity.Status.Id == (int)CashFormStatusEnum.Borrador)
            {
                var cashToPresentate = await this.GetCashToPresentateAsync(currentUser.Id);
                entity.AddCashes(cashToPresentate.ToList());
                var expensesToPresentate = await this.GetExpensesToPresentateAsync(currentUser.Id);
                entity.AddExpenses(expensesToPresentate.ToList());
            }

            entity.PreviousStatus = await FindById<Domain.Entities.CashFormAggregate.CashFormStatus>((int)entity.Status.Id);
            entity.Status = await FindById<Domain.Entities.CashFormAggregate.CashFormStatus>((int)request.Status);

            if (entity.Status.Id == (int)CashFormStatusEnum.Aprobado)
            {
                entity.ApprovalDate = _dateTimeService.Now;
            }

            #endregion
            entity.AddAudit(currentUser, _dateTimeService.Now);
            if (entity.User != null) this.SendEmailToUser(entity.User, currentUser, request.Status);

            _unitOfWork.Repository<Domain.Entities.CashFormAggregate.CashForm>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

        #region Cashes
        private async Task<IReadOnlyCollection<Domain.Entities.CashFormAggregate.CashFormMoney>> GetCashToPresentateAsync(long userId)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.CashFormAggregate.CashFormMoney>()
                .ListAsync(new MoneyByUserSpecification(userId));

            //Guard.Against.LunchToRenderValid(list);
            return list;
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

        #region Emails

        private async void SendEmailToUser(User sourceUser, User currentUser, CashFormStatusEnum status)
        {
            string action;
            switch (status)
            {
                case CashFormStatusEnum.Aprobado:
                    action = "aprobó";
                    break;
                case CashFormStatusEnum.Rechazado:
                    action = "rechazó";
                    break;
                case CashFormStatusEnum.Revisado:
                    action = "revisó";
                    break;
                default:
                    action = "cambió de estado";
                    break;
            }
            var email = new Email
            {
                Subject = "Su planilla fue " + status,
                BodyMessage = $"El usuario {currentUser.Email} {action} su planilla de caja chica. "
            };
            email.SendToEmailList.Add(sourceUser.Email);
            await _emailService.SendEmailAsync(email);
        }
        #endregion
    }
}
