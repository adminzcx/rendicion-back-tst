using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Domain.Entities.UserAggregate
{
    public class Branch : BaseNameCodeEntity
    {
        protected Branch(string code, string name)
            : base(code, name)
        { }

        public Branch(string code, string name, string latitud, string longitud, SubZone subZone)
            : this(code, name)
        {
            Latitud = latitud;
            Longitud = longitud;
            SubZone = subZone;
        }

        public virtual string Latitud { get; private set; }
        public virtual string Longitud { get; private set; }
        public virtual SubZone SubZone { get; private set; }
    }
}
