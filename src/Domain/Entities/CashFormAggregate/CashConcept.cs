using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Domain.Entities.CashFormAggregate
{
    public class CashConcept : BaseNameEntity
    {
        public CashConcept(string name)
            : base(name)
        {
        }

        public virtual CostCenter CostCenter { get; set; }
        public string Calipso { get; set; }
    }
}