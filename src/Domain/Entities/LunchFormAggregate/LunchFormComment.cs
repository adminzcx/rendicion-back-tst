using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;

namespace Prome.Viaticos.Server.Domain.Entities.LunchFormAggregate
{
    public class LunchFormComment : BaseEntity
    {
        protected LunchFormComment() : base() { }

        public LunchFormComment(User user, string description, DateTime date)
        {
            this.CommentUser = user;
            this.Description = description;
            this.CommentDate = date;
        }

        public virtual LunchForm LunchForm { get; set; }

        public DateTime CommentDate { get; set; }

        public string Description { get; set; }

        public virtual User CommentUser { get; set; }

        public bool IsDeleted { get; set; } = false;


    }
}
