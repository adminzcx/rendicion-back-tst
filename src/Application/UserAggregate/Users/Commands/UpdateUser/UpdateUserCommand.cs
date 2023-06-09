﻿using MediatR;
using System;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Commands.UpdateUser
{


    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string EmployeeRecord { get; set; }

        public bool IsAdministrator { get; set; }

        public string BusinessUnit { get; set; }

        public string BranchFrom { get; set; }

        public string Category { get; set; }

        public string Position { get; set; }

        public string Cuit { get; set; }

        public Int64? TarjetaYPF { get; set; }

        public bool? YPFRuta { get; set; }
    }
}
