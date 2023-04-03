using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Domain.Entities.UserAggregate
{
    public class Sector : BaseNameCodeEntity
    {
        protected Sector(string code, string name)
            : base(code, name)
        { }

        public Sector(string code, string name, Management management)
            : this(code, name)
        {
            Management = management;
        }

        public virtual Management Management { get; private set; }

        public bool HasSpecialPermissions { get; set; } = false;
    }
}