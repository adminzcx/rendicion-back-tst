using Prome.Viaticos.Server.Application._Common.Specifications;
using System;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Specifications
{
    public sealed class LunchMonthlyByUserDateSpecification : BaseSpecification<Domain.Entities.LunchAggregate.Lunch>
    {
        public LunchMonthlyByUserDateSpecification(long userId, long id, DateTime date)
            : base(x => x.User.Id == userId
                        && x.LunchDate >= new DateTime(date.Year, date.Month, 1)
                        && x.LunchDate <= new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays((-1))
                        && x.Id != id
                        && x.IsDeleted != true)
        {

        }
    }
}