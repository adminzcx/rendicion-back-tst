namespace Prome.Viaticos.Server.Domain._Common
{
    public abstract class BaseNameEntity : BaseEntity
    {
        public BaseNameEntity(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}