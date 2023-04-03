using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.DatosMillanAggregate;
using System;
using System.Collections.Generic;


namespace Prome.Viaticos.Server.Application.DatosMillanAggregate.Dtos
{
    public class DatosMillanDto : IMapFrom<DatosMillan>
    {
    
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Cuit { get; set; }

        public string EmployeeRecord { get; set; }

        public bool IsAdministrator { get; set; }

        public DateTime? LastModified { get; set; }

        public DateTime? DisabledDate { get; set; }

        public DateTime? Created { get; set; }
    }

   
}