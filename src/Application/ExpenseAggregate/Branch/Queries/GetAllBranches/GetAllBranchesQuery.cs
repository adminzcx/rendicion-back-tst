
using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Branch.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Branch.Queries.GetAllBranches
{

    public class GetAllBranchesQuery : IRequest<ICollection<BranchDto>>
    {
    }
}
