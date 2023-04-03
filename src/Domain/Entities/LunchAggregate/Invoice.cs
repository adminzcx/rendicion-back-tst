using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Domain.Entities.LunchAggregate
{
    public class Invoice : BaseNameCodeEntity
    {
        protected Invoice(string code, string name)
            : base(code, name)
        { }
    }
}
