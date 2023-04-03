using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate
{
    public class TechnicalVisit : BaseNameCodeEntity
    {
        public TechnicalVisit(string code, string name)
            : base(code, name)
        { }
    }
}