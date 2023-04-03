namespace Prome.Viaticos.Server.Domain._Common
{
    public abstract class BaseNameCodeEntity : BaseEntity
    {
        public BaseNameCodeEntity(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; private set; }

        public string Name { get; private set; }
    }
}