using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using Prome.Viaticos.Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prome.Viaticos.Server.Domain.Entities.ExpenseFormAggregate
{
    public class ExpenseForm : BaseEntity
    {
        #region Properties
        public virtual User User { get; set; }

        public virtual User AuthorizeUser { get; set; }

        public virtual User ReviewUser { get; set; }

        public string ExpenseFormNumber { get; set; } = "";

        public DateTime PresentationDate { get; set; }

        public decimal? Amount { get; set; }

        public string Description { get; set; }

        public virtual ExpenseFormStatus Status { get; set; }

        public virtual ExpenseFormStatus PreviousStatus { get; set; }

        public virtual User AdministratorUser { get; set; }

        public bool IsReset { get; set; } = false;

        public bool IsDeleted { get; set; } = false;

        public bool IsPaid { get; set; } = false;

        public DateTime ApprovalDate { get; set; }

        private List<Expense> _expenses = new List<Expense>();

        public virtual IReadOnlyList<Expense> Expenses => _expenses.Where(x => x.IsDeleted != true).ToList();

        private List<ExpenseFormAudit> _audits = new List<ExpenseFormAudit>();

        public virtual IReadOnlyList<ExpenseFormAudit> Audits => _audits.ToList();

        private List<ExpenseFormComment> _comments = new List<ExpenseFormComment>();

        public virtual IReadOnlyList<ExpenseFormComment> Comments => _comments.Where(x => x.IsDeleted != true).ToList();
        #endregion


        #region Audits
        public virtual void AddAudit(User user, DateTime date)
        {
            var audit = new ExpenseFormAudit(user, this.Status, this.Description, this.Amount, date);
            _audits.Add(audit);
        }


        #endregion


        #region Expenses
        public virtual void AddExpenses(List<Expense> expensesToPresentate)
        {
            _expenses.AddRange(expensesToPresentate);
        }

        public ExpenseFormStatusEnum GetApprovalStatusLevel(ExpenseFormStatusEnum expenseFormStatusEnum)
        {

            switch (expenseFormStatusEnum)
            {
                case ExpenseFormStatusEnum.Presentada:
                    return ExpenseFormStatusEnum.Autorizado;

                case ExpenseFormStatusEnum.Autorizado:
                    return ExpenseFormStatusEnum.Revisado;

                case ExpenseFormStatusEnum.Revisado:
                    return ExpenseFormStatusEnum.Aprobado;

                default:
                    return ExpenseFormStatusEnum.Presentada;
            }
        }

        #endregion


        #region Comments
        public virtual void AddComments(List<ExpenseFormComment> commentsToAdd)
        {
            _comments.AddRange(commentsToAdd);
        }
        public virtual void AddComment(ExpenseFormComment commentToAdd)
        {
            _comments.Add(commentToAdd);
        }
        #endregion


    }
}

