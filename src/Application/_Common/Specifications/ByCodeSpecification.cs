using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Application._Common.Specifications
{
    public class ByCodeSpecification<T>
        : BaseSpecification<T>
        where T : BaseNameCodeEntity
    {
        public ByCodeSpecification(string code)
            : base(x => x.Code.Equals(code))
        {
        }
    }
}
