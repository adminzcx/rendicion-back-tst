using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchFormComment.Commands.CreateLunchFormComment
{
    public class CreateLunchFormCommentCommandHandler : CommandHandler<CreateLunchFormCommentCommand>
    {
        private readonly IDateTime _dateTimeService;

        public CreateLunchFormCommentCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper,
            IDateTime dateTimeService)
    : base(unitOfWork, mapper)
        {
            _dateTimeService = dateTimeService;
        }

        public override async Task<Unit> Handle(CreateLunchFormCommentCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await this.GetCurrentUserAsync(request.Email);
            var currentDate = _dateTimeService.Now;
            var entity = new Domain.Entities.LunchFormAggregate.LunchFormComment(currentUser, request.Description, currentDate);
            var form = await FindById<Domain.Entities.LunchFormAggregate.LunchForm>(request.ExpenseFormId);
            entity.LunchForm = form;
            await _unitOfWork.Repository<Domain.Entities.LunchFormAggregate.LunchFormComment>().AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
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
    }
}
