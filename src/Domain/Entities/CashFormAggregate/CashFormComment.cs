using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;

namespace Prome.Viaticos.Server.Domain.Entities.CashFormAggregate
{
    public class CashFormComment : BaseEntity
    {
        protected CashFormComment()
        {
        }

        public CashFormComment(User user, string description, DateTime date)
        {
            CommentUser = user;
            Description = description;
            CommentDate = date;
        }

        public virtual CashForm CashForm { get; set; }

        public DateTime CommentDate { get; set; }

        public string Description { get; set; }

        public virtual User CommentUser { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}