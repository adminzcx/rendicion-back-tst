using Prome.Viaticos.Server.Application._Common.Specifications;
using System;

namespace Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Specifications
{
    public class LunchStopsByValidationDateSpecification : BaseSpecification<Domain.Entities.AdminAggregate.LunchStops>
    {
        public LunchStopsByValidationDateSpecification(DateTime date, Boolean isMonthly) : base(x => x.IsDeleted != true
                                                                                                     && x.ValidityStartDate <= date
                                                                                                     && x.IsMonthly == isMonthly)
        {

        }
    }
}
