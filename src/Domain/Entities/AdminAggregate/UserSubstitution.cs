
using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;

namespace Prome.Viaticos.Server.Domain.Entities.AdminAggregate
{

    public class UserSubstitution : BaseEntity
    {
        protected UserSubstitution()
            : base()
        { }
        public UserSubstitution(User user, User replaceByUser)
        {
            this.User = user;
            this.ReplaceByUser = replaceByUser;
        }

        public virtual User User { get; set; }

        public virtual User ReplaceByUser { get; set; }

        public DateTime CreatedDate { get; set; }

        public Boolean IsDeleted { get; set; } = false;
    }
}