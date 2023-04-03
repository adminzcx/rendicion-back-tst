using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.AdminAggregate.LunchStops.Specifications
{
    public sealed class LunchStopByIdSpecification : BaseSpecification<Domain.Entities.AdminAggregate.LunchStops>
    {
        public LunchStopByIdSpecification(long id)
            : base(x => x.Id == id)
        {

        }
    }
}
