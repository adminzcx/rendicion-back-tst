using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Domain.Entities.UserAggregate
{
    public class Branch : BaseNameCodeEntity
    {
        protected Branch(string code, string name)
            : base(code, name)
        { }

        public Branch(string code, string name, SubZone subZone)
            : this(code, name)
        {
            SubZone = subZone;
        }

        public virtual SubZone SubZone { get; private set; }
    }
}
