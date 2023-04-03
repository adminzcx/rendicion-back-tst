using System;

namespace Prome.Viaticos.Server.Domain._Common
{
    public abstract class DisableableAuditableEntity : AuditableEntity
    {
        public DateTime? DisabledDate { get; private set; }

        public void Disable(DateTime dateTime)
        {
            DisabledDate = dateTime;
        }
    }
}
