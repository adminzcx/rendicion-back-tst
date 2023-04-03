using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;

namespace Prome.Viaticos.Server.Domain.Entities.ExpenseFormAggregate
{
    public class ExpenseFormComment : BaseEntity
    {
        protected ExpenseFormComment() : base() { }

        public ExpenseFormComment(User user, string description, DateTime date)
        {
            this.CommentUser = user;
            this.Description = description;
            this.CommentDate = date;
        }

        public virtual ExpenseForm ExpenseForm { get; set; }

        public DateTime CommentDate { get; set; }

        public string Description { get; set; }

        public virtual User CommentUser { get; set; }

        public bool IsDeleted { get; set; } = false;


    }
}
