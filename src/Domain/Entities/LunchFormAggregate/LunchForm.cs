using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.LunchAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prome.Viaticos.Server.Domain.Entities.LunchFormAggregate
{
    public class LunchForm : BaseEntity
    {
        public virtual Branch Branch { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public DateTime Date { get; set; }

        public DateTime Cai { get; set; }

        public DateTime ApprovalDate { get; set; }

        public string InvoiceType { get; set; }

        public string InvoiceNumber { get; set; }

        public int NumberOfTickets { get; set; }

        public string LunchFormNumber { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Iva { get; set; }

        public decimal Total { get; set; }

        public int BussinesDays { get; set; }

        public string ExceptionResponse { get; set; }

        public decimal CostPerLunch { get; set; }

        public virtual User User { get; set; }

        public virtual LunchFormStatus Status { get; set; }

        public virtual LunchFormStatus PreviousStatus { get; set; }

        public bool IsPaid { get; set; } = false;

        private List<Lunch> _lunches = new List<Lunch>();

        public virtual IReadOnlyList<Lunch> Lunches => _lunches.Where(x => x.IsDeleted != true).ToList();

        private List<LunchFormAudit> _audits = new List<LunchFormAudit>();

        public virtual IReadOnlyList<LunchFormAudit> Audits => _audits.ToList();

        private List<LunchFormComment> _comments = new List<LunchFormComment>();

        public virtual IReadOnlyList<LunchFormComment> Comments => _comments.Where(x => x.IsDeleted != true).ToList();

        public bool IsDeleted { get; set; } = false;

        #region Lunches
        public virtual void AddLunches(List<Lunch> lunchesToPresentate)
        {
            _lunches.AddRange(lunchesToPresentate);
        }
        #endregion

        #region Audits
        public virtual void AddAudit(User user, DateTime date)
        {
            var audit = new LunchFormAudit(user, this.Status, this.Total, date);
            _audits.Add(audit);
        }

        public virtual void AddAudit(User user, DateTime date, string status)
        {
            var audit = new LunchFormAudit(user, status, date);
            _audits.Add(audit);
        }
        #endregion

        #region Comments
        public virtual void AddComments(List<LunchFormComment> commentsToAdd)
        {
            _comments.AddRange(commentsToAdd);
        }
        public virtual void AddComment(LunchFormComment commentToAdd)
        {
            _comments.Add(commentToAdd);
        }
        #endregion

    }
}
