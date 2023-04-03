using Ardalis.GuardClauses;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Queries.GetDashboardCashForm
{
    public class GetDashboardCashFormQueryHandler : QueryHandler<GetDashboardCashFormQuery, ICollection<DashboardDto>>
    {
        public GetDashboardCashFormQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<DashboardDto>> Handle(GetDashboardCashFormQuery request, CancellationToken cancellationToken)
        {

            var currentUser = await this.GetCurrentUserAsync(request.Email);

            return await this.GetDashboard(currentUser);
        }
        private async Task<Collection<DashboardDto>> GetDashboard(User currentUser)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.CashFormAggregate.CashForm>()
                .ListAsync(new CashFormByUserSpecification(currentUser.Id));

            var result = new Collection<DashboardDto>();
            var dashboardList = list.GroupBy(x => x.Status.Name).ToList();
            foreach (var item in dashboardList.Select(row => new DashboardDto
            {
                Status = row.Key,
                Total = row.Count()
            }))
            {
                result.Add(item);
            }


            return result;
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
