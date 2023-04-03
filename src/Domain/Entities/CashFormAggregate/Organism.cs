using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Domain.Entities.CashFormAggregate
{
    public class Organism : BaseNameEntity
    {
        public Organism(string name)
            : base(name)
        {
        }

        public bool IsDefault { get; set; }
    }
}