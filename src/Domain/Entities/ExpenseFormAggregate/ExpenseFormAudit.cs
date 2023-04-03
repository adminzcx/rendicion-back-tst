using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;

namespace Prome.Viaticos.Server.Domain.Entities.ExpenseFormAggregate
{
    public class ExpenseFormAudit : BaseEntity
    {
        protected ExpenseFormAudit()
        { }

        public ExpenseFormAudit(User user, ExpenseFormStatus status, string description, decimal? amount, DateTime date)
            : base()
        {
            this.Amount = amount;
            this.Status = status.Name;
            this.UserPosition = user.Position.Code;
            this.UserName = user.Name;
            this.AuditUser = user;
            this.Description = description;
            this.AuditDate = date;
        }

        public virtual ExpenseForm ExpenseForm { get; set; }

        public DateTime AuditDate { get; set; }

        public decimal? Amount { get; set; }

        public string Description { get; set; }

        public string UserPosition { get; set; }

        public string UserName { get; set; }

        public string Status { get; set; }

        public virtual User AuditUser { get; set; }

        public Boolean IsDeleted { get; set; } = false;

    }
}

