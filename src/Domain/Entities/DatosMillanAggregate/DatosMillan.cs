using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Domain.Entities.DatosMillanAggregate
{
    public class DatosMillan : BaseEntity
    {
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Cuit { get; set; }

        public string EmployeeRecord { get; set; }

        public bool IsAdministrator { get; set; }

        public DateTime? LastModified { get; set; }

        public DateTime? DisabledDate { get; set; }

        public DateTime? Created { get; set; }

        public void Clean()
        {
            throw new NotImplementedException();
        }
    }

}
