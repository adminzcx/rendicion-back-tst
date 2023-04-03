using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Domain.Entities.UserAggregate
{
    public class SubZone : BaseNameCodeEntity
    {
        protected SubZone(string code, string name)
            : base(code, name)
        { }

        public SubZone(string code, string name, Zone zone)
            : this(code, name)
        {
            Zone = zone;
        }

        public virtual Zone Zone { get; private set; }
    }
}