using System;

namespace Prome.Viaticos.Server.Domain._Common
{


    public abstract class AuditableEntity : BaseEntity
    {
        public long CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public long LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
