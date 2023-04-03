using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using System;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Specifications
{
    public sealed class UserAbsenteeismByUserSpecification : BaseSpecification<UserAbsenteeism>
    {
        public UserAbsenteeismByUserSpecification(long userId, DateTime date)
            : base(x =>
                x.User.Id == userId
                && x.StartDate <= new DateTime(date.Year, date.Month, date.Day)
                && x.EndDate >= new DateTime(date.Year, date.Month, date.Day)
            )
        { }
    }
}