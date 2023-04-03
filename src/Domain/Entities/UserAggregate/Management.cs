using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Domain.Entities.UserAggregate
{
    public class Management : BaseNameCodeEntity
    {
        public Management(string code, string name)
            : base(code, name)
        { }

        public bool HasSpecialPermissions { get; set; } = false;
    }
}