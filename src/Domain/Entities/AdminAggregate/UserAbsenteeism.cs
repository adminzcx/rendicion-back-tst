
using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;

namespace Prome.Viaticos.Server.Domain.Entities.AdminAggregate
{

    public class UserAbsenteeism : BaseEntity
    {
        protected UserAbsenteeism()
            : base()
        { }


        public UserAbsenteeism(User user, DateTime? startDate, DateTime? endDate, DateTime importedDate, string source)
        {
            User = user;
            StartDate = startDate;
            EndDate = endDate;
            ImportedDate = importedDate;
            Source = source;
        }

        public virtual User User { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime ImportedDate { get; set; }

        public string Source { get; set; }


    }
}