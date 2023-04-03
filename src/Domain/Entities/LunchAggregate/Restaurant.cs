using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;

namespace Prome.Viaticos.Server.Domain.Entities.LunchAggregate
{
    public class Restaurant : BaseEntity
    {
        public Restaurant()
            : base()
        {

        }
        public string Name { get; set; }

        public long Cuit { get; set; }

        public virtual Branch Branch { get; set; }

        public DateTime StartDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
