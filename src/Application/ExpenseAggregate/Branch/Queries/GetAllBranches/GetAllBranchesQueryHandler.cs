using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Branch.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Branch.Queries.GetAllBranches
{
    public class GetAllBranchesQueryHandler : QueryHandler<GetAllBranchesQuery, ICollection<BranchDto>>
    {
        public GetAllBranchesQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<BranchDto>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork
                .Repository<Domain.Entities.UserAggregate.Branch>()
                .ListAllAsync();

            return Map(list);
        }
    }
}
