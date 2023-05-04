using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;

namespace Prome.Viaticos.Server.Application.DatosMillanAggregate.Commands.UpdateUser
{
    public class UpdateDatosMillanCommand :IRequest    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string EmployeeRecord { get; set; }

        public bool IsAdministrator { get; set; }

        //public string BusinessUnit { get; set; }

        //public string BranchFrom { get; set; }

        //public string Category { get; set; }

        //public string Position { get; set; }

        public string Cuit { get; set; }
    }
}

