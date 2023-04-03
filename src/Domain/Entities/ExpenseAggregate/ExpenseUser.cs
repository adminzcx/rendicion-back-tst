using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;

namespace Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate
{
    public class ExpenseUser : BaseEntity
    {
        public ExpenseUser()
            : base()
        { }
        public DateTime ExpenseDate { get; set; }

        public virtual Expense Expense { get; set; }

        public virtual User User { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}