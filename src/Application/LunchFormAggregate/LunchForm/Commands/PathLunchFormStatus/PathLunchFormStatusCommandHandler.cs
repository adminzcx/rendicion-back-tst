using Ardalis.GuardClauses;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Specifications;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.LunchAggregate;
using Prome.Viaticos.Server.Domain.Entities.LunchFormAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using Prome.Viaticos.Server.Domain.Enums;
using Prome.Viaticos.Server.Domain.ValueObjects.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Commands.PathLunchFormStatus
{

    public class PathLunchFormStatusCommandHandler : CommandHandler<PathLunchFormStatusCommand>
    {
        private readonly IEmailService _emailService;
        private readonly IDateTime _dateTimeService;

        public PathLunchFormStatusCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IDateTime dateTimeService,
            IEmailService emailService)
            : base(unitOfWork)
        {
            _emailService = emailService;
            _dateTimeService = dateTimeService;
        }

        public override async Task<Unit> Handle(PathLunchFormStatusCommand request, CancellationToken cancellationToken)
        {

            #region Entity
            var currentUser = await this.GetCurrentUserAsync(request.Email);

            var entity = await FindById<Domain.Entities.LunchFormAggregate.LunchForm>(request.Id);

            if (entity.PreviousStatus is null && entity.Status.Id == (int)LunchFormStatusEnum.Borrador)
            {
                var lunchesToPresentate = await this.GetLunchesToPresentateAsync(currentUser.Id);
                entity.AddLunches(lunchesToPresentate.ToList());
            }

            entity.PreviousStatus = await FindById<LunchFormStatus>((int)entity.Status.Id);
            entity.Status = await FindById<LunchFormStatus>((int)request.Status);
            #endregion
            entity.AddAudit(currentUser, _dateTimeService.Now);
            if (entity.User != null) this.SendEmailToUser(entity.User, currentUser, request.Status);

            _unitOfWork.Repository<Domain.Entities.LunchFormAggregate.LunchForm>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

        #region Lunches
        private async Task<IReadOnlyCollection<Lunch>> GetLunchesToPresentateAsync(long userId)
        {
            var list = await _unitOfWork
                .Repository<Lunch>()
                .ListAsync(new LunchByUserSpecification(userId));

            Guard.Against.LunchToRenderValid(list);
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

        private async void SendEmailToUser(User sourceUser, User currentUser, LunchFormStatusEnum status)
        {
            string action;
            switch (status)
            {
                case LunchFormStatusEnum.Aprobado:
                    action = "aprobó";
                    break;
                case LunchFormStatusEnum.Rechazado:
                    action = "rechazó";
                    break;
                case LunchFormStatusEnum.Revisado:
                    action = "revisó";
                    break;
                default:
                    action = "cambió de estado";
                    break;
            }
            var email = new Email
            {
                Subject = "Su planilla fue " + status,
                BodyMessage = $"El usuario {currentUser.Email} {action} su planilla de almuerzos. "
            };
            email.SendToEmailList.Add(sourceUser.Email);
            await _emailService.SendEmailAsync(email);
        }
        #endregion

    }
}
