using Prome.Viaticos.Server.Application._Common.Specifications;
using System;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Specifications
{
    public sealed class LunchByUserDateSpecification : BaseSpecification<Domain.Entities.LunchAggregate.Lunch>
    {
        public LunchByUserDateSpecification(long userId, long id, DateTime date)
            : base(x => x.User.Id == userId
                        && x.LunchDate >= date && x.LunchDate <= date
                        && x.Id != id
                        && x.IsDeleted != true)
                        
        {

        }
    }
}
