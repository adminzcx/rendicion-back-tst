using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Domain.Entities.UserAggregate
{
    public class Zone : BaseNameCodeEntity
    {
        public Zone(string code, string name)
            : base(code, name)
        { }
    }
}