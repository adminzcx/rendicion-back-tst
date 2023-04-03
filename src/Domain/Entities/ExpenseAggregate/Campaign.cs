using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate
{
    public class Campaign : BaseNameEntity
    {
        public Campaign(string name)
            : base(name)
        { }

        public bool IsDeleted { get; set; } = false;
    }
}