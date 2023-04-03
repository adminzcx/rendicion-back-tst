using Prome.Viaticos.Server.Application._Common.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Branch.Specifications
{
    public sealed class BranchById : BaseSpecification<Domain.Entities.UserAggregate.Branch>
    {
        public BranchById(long branchId)
               : base(x => x.Id == branchId)
        {
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
