using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Domain.Entities.UserAggregate
{
    public class Category : BaseNameCodeEntity
    {
        public Category(string code, string name)
            : base(code, name)
        { }
    }
}