
using Ardalis.GuardClauses;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Specifications;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Queries.GetAllPendingExpenses
{


    public class GetAllPendingExpensesQueryHandler : QueryHandler<GetAllPendingExpensesQuery, ICollection<ExpenseListDto>>
    {
        public GetAllPendingExpensesQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<ExpenseListDto>> Handle(GetAllPendingExpensesQuery request, CancellationToken cancellationToken)
        {

            var currentUser = await this.GetCurrentUserAsync(request.Email);

            var list = await _unitOfWork
                .Repository<Domain.Entities.ExpenseAggregate.Expense>()
                .ListAsync(spec: new ExpensePendingStatusByUserSpecification(currentUser.Id));

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
