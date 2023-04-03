using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos
{


    public class UserDto : IMapFrom<User>
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Identification { get; set; }

        public long CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public long LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public string Name => this.FirstName + " " + this.LastName;

        public string EmployeeRecord { get; set; }

        public virtual Category Category { get; set; }

        public virtual Branch BranchFrom { get; set; }

        public virtual Position Position { get; set; }

        public string Cuit { get; set; }

        public Int64? TarjetaYPF { get; set; }

        public bool? YPFRuta { get; set; }

        public bool IsAdministrator { get; set; }
    }
}
