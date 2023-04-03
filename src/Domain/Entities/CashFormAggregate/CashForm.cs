using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prome.Viaticos.Server.Domain.Entities.CashFormAggregate
{
    public class CashForm : BaseEntity
    {
        #region Properties
        public string Period { get; set; }

        public DateTime? PresentationDate { get; set; }

        public DateTime ApprovalDate { get; set; }

        public virtual User User { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual Organism Organism { get; set; }

        public string CashFormNumber { get; set; } = "";

        public decimal? SubTotalCoins { get; set; }

        public decimal? SubTotalCash { get; set; }

        public decimal? TotalCash { get; set; }

        public decimal? TotalExpense { get; set; }

        public DateTime? CreditCardDate { get; set; }

        public decimal? TotalCreditCard { get; set; }

        public decimal? TotalPending { get; set; }

        public DateTime? TotalPendingDate { get; set; }

        public decimal? FundTotal { get; set; }

        public decimal? BalanceTotal { get; set; }

        public decimal? Total { get; set; }

        public decimal? TotalDifference { get; set; }

        public string Description { get; set; }

        public virtual CashFormStatus Status { get; set; }

        public virtual CashFormStatus PreviousStatus { get; set; }

        public bool IsDeleted { get; set; } = false;
      
        public bool IsPaid { get; set; } = false;

        private List<CashFormMoney> _cashes = new List<CashFormMoney>();

        public virtual IReadOnlyList<CashFormMoney> Cashes => _cashes.Where(x => x.IsDeleted != true).ToList();

        private List<CashFormExpense> _expenses = new List<CashFormExpense>();

        public virtual IReadOnlyList<CashFormExpense> Expenses => _expenses.Where(x => x.IsDeleted != true).ToList();

        private List<CashFormAudit> _audits = new List<CashFormAudit>();

        public virtual IReadOnlyList<CashFormAudit> Audits => _audits.ToList();

        private List<CashFormComment> _comments = new List<CashFormComment>();

        public virtual IReadOnlyList<CashFormComment> Comments => _comments.Where(x => x.IsDeleted != true).ToList();


        #endregion


        #region Cashs
        public virtual void AddCashes(List<CashFormMoney> cashToPresentate)
        {
            _cashes.AddRange(cashToPresentate);
        }
        #endregion


        #region Expenses
        public virtual void AddExpenses(List<CashFormExpense> expenseToPresentate)
        {
            _expenses.AddRange(expenseToPresentate);
        }
        #endregion

        #region Audits
        public virtual void AddAudit(User user, DateTime date)
        {
            var audit = new CashFormAudit(user, this.Status, this.Total, date);
            _audits.Add(audit);
        }

        public virtual void AddAudit(User user, DateTime date, string status)
        {
            var audit = new CashFormAudit(user, status, date);
            _audits.Add(audit);
        }
        #endregion

        #region Comments
        public virtual void AddComments(List<CashFormComment> commentsToAdd)
        {
            _comments.AddRange(commentsToAdd);
        }
        public virtual void AddComment(CashFormComment commentToAdd)
        {
            _comments.Add(commentToAdd);
        }
        #endregion
    }
}

