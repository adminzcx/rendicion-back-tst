using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.ExpenseFormAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using Prome.Viaticos.Server.Domain.Enums;
using Prome.Viaticos.Server.Domain.ValueObjects.Common;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.PathExpenseFormStatus
{

    public class PathExpenseFormStatusCommandHandler : CommandHandler<PathExpenseFormStatusCommand>
    {
        private readonly IDateTime _dateTimeService;
        private readonly IEmailService _emailService;


        public PathExpenseFormStatusCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IDateTime dateTimeService,
            IEmailService emailService)
            : base(unitOfWork)
        {
            _dateTimeService = dateTimeService;
            _emailService = emailService;


        }
        public override async Task<Unit> Handle(PathExpenseFormStatusCommand request, CancellationToken cancellationToken)
        {

            #region Entity
            var currentUser = await this.GetCurrentUserAsync(request.Email);
            var entity = await FindById<Domain.Entities.ExpenseFormAggregate.ExpenseForm>(request.Id);
            entity.PreviousStatus = await FindById<ExpenseFormStatus>((int)entity.Status.Id);

            if (request.ToReview)
            {
                entity.Status = await FindById<ExpenseFormStatus>((int)entity.GetApprovalStatusLevel((ExpenseFormStatusEnum)entity.Status.Id));
            }

            if (request.ToReject1)
            {
                entity.Status = await FindById<ExpenseFormStatus>((int)ExpenseFormStatusEnum.Rechazado);
                entity.IsReset = false;
            }

            if (request.ToReject2)
            {
                entity.Status = await FindById<ExpenseFormStatus>((int)ExpenseFormStatusEnum.Rechazado);
                entity.IsReset = true;
            }

            foreach (var itemExpense in entity.Expenses)
            {
                itemExpense.RevertEnabled = false;
            }


            if (entity.Status.Id == (int)ExpenseFormStatusEnum.Revisado)
            {
                entity.ReviewUser = currentUser;
            }

            if (entity.Status.Id == (int)ExpenseFormStatusEnum.Autorizado)
            {
                entity.AuthorizeUser = currentUser;
                entity.ApprovalDate = _dateTimeService.Now;
            }

            entity.AddAudit(currentUser, _dateTimeService.Now);
            entity.AdministratorUser = await this.GetNextPositionLevelAsync(currentUser);
            #endregion


            this.SendEmailToUser(entity.User, currentUser);
            if (entity.AdministratorUser != null) this.SendEmailToUser(entity.AdministratorUser, currentUser);

            _unitOfWork.Repository<Domain.Entities.ExpenseFormAggregate.ExpenseForm>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

        #region Users
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
                 .ListAsync(new ByEmployeePositionSpecification(position.Name, subZoneId, zoneId, sectorId));

            if (!users.Any()) return null;
            return users.First();
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

        private async void SendEmailToUser(User adminUser, User currentUser)
        {
            var email = new Email();
            email.Subject = "Usted tiene una nueva planilla de gastos para aprobar.";
            email.BodyMessage = $"El usuario {currentUser.Email} revisó una nueva planilla de gastos. ";
            email.SendToEmailList.Add(adminUser.Email);
            await _emailService.SendEmailAsync(email);
        }
        #endregion



    }
}
