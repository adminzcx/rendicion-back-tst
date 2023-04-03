using Ardalis.GuardClauses;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Dtos;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Queries.GetCashFormAmountByBranch
{
    public class GetCashFormAmountByBranchQueryHandler : QueryHandler<GetCashFormAmountByBranchQuery
                                                            , CashFormAmountDto>
    {
        public GetCashFormAmountByBranchQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<CashFormAmountDto> Handle(GetCashFormAmountByBranchQuery request
                                                                           , CancellationToken cancellationToken)
        {
            var currentUser = await this.GetCurrentUserAsync(request.Email);

            //var list = await _unitOfWork
            //    .Repository<Domain.Entities.CashFormAggregate.CashFormAmount>()
            //    .SingleOrDefaultAsync(new CashFormAmountByBranchIdSpecification(currentUser.Branch.Id));
            var list = await _unitOfWork
                .Repository<Domain.Entities.CashFormAggregate.CashFormAmount>()
                .SingleOrDefaultAsync(new CashFormAmountByBranchIdSpecification(currentUser.BranchFrom.Id));

            return Map(list);
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
