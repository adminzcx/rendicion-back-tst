using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications
{
    public class ByEmployeeTarjetaYPFSpecification : BaseSpecification<User>
    {
        public ByEmployeeTarjetaYPFSpecification(string tarjetaYPF)
            : base(x => x.TarjetaYPF.Equals(tarjetaYPF))
        {
        }
    }
}
