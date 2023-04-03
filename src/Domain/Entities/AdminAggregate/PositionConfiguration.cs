using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Domain.Entities.AdminAggregate
{
    public class PositionConfiguration : BaseEntity
    {
        protected PositionConfiguration()
            : base()
        { }

        public PositionConfiguration(Reason reason, Concept concept, Position position)
        {
            this.Reason = reason;
            this.Concept = concept;
            this.Position = position;
        }

        public virtual Position Position { get; set; }

        public virtual Reason Reason { get; set; }

        public virtual Concept Concept { get; set; }

    }
}