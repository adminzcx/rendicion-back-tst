using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;

namespace Prome.Viaticos.Server.Domain.Entities.CashFormAggregate
{
    public class CashFormAudit : BaseEntity
    {
        protected CashFormAudit()
        {
        }

        public CashFormAudit(User user, CashFormStatus status, decimal? amount, DateTime date)
        {
            Amount = amount;
            Status = status.Name;
            UserPosition = user.Position.Code;
            UserName = user.Name;
            AuditUser = user;
            AuditDate = date;
        }

        public CashFormAudit(User user, string status, DateTime date)
        {
            Status = status;
            UserPosition = user.Position.Code;
            UserName = user.Name;
            AuditUser = user;
            AuditDate = date;
        }


        public virtual CashForm CashForm { get; set; }

        public DateTime AuditDate { get; set; }

        public decimal? Amount { get; set; }

        public string Description { get; set; }

        public string UserPosition { get; set; }

        public string UserName { get; set; }

        public string Status { get; set; }

        public virtual User AuditUser { get; set; }
    }
}