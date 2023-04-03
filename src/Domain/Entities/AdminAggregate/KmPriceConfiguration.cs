using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using Prome.Viaticos.Server.Domain.Enums;
using System;

namespace Prome.Viaticos.Server.Domain.Entities.AdminAggregate
{
    public class KmPriceConfiguration : BaseEntity
    {
        protected KmPriceConfiguration()
            : base()
        {
        }
        public KmPriceConfiguration(decimal price, KmPriceTypeEnum type)
        {
            this.Price = price;
            this.TypeKm = (int)type;
        }
        public DateTime? StartDate { get; set; }

        public decimal Price { get; set; }

        public virtual Zone Zone { get; set; }

        public virtual SubZone SubZone { get; set; }

        public virtual User User { get; set; }

        public bool IsDeleted { get; set; } = false;

        public int TypeKm { get; set; }

    }

}