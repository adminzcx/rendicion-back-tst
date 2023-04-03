using Prome.Viaticos.Server.Domain._Common;
using System;

namespace Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate
{
    public class ExpenseAdvice : BaseEntity
    {
        protected ExpenseAdvice()
        { }

        public ExpenseAdvice(string title, string description)
            : base()
        {
            this.Title = title;
            this.Description = description;
            this.AdviceDate = DateTime.Now;
        }

        public virtual Expense Expense { get; set; }

        public DateTime AdviceDate { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }
    }
}

