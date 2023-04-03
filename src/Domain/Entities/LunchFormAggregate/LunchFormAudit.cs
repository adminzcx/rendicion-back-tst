using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;

namespace Prome.Viaticos.Server.Domain.Entities.LunchFormAggregate
{
    public class LunchFormAudit : BaseEntity
    {
        protected LunchFormAudit()
        { }

        public LunchFormAudit(User user, LunchFormStatus status, decimal? amount, DateTime date)
            : base()
        {
            this.Amount = amount;
            this.Status = status.Name;
            this.UserPosition = user.Position.Code;
            this.UserName = user.Name;
            this.AuditUser = user;
            this.AuditDate = date;
        }

        public LunchFormAudit(User user, string status, DateTime date)
            : base()
        {

            this.Status = status;
            this.UserPosition = user.Position.Code;
            this.UserName = user.Name;
            this.AuditUser = user;
            this.AuditDate = date;
        }


        public virtual LunchForm LunchForm { get; set; }

        public DateTime AuditDate { get; set; }

        public decimal? Amount { get; set; }

        public string Description { get; set; }

        public string UserPosition { get; set; }

        public string UserName { get; set; }

        public string Status { get; set; }

        public virtual User AuditUser { get; set; }


    }
}

