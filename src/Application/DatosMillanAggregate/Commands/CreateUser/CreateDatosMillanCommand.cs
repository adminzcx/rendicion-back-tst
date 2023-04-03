
using System;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Mappings;



namespace Prome.Viaticos.Server.Application.DatosMillanAggregate.Commands.CreateUser
{
    public class CreateDatosMillanCommand : IRequest , IMapFrom<Domain.Entities.DatosMillanAggregate.DatosMillan>
    {
    
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string EmployeeRecord { get; set; }

        public DateTime DisabledDate { get; set; }

        public bool IsAdministrator { get; set; }

        public string Cuit { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDatosMillanCommand, Domain.Entities.DatosMillanAggregate.DatosMillan>();
        }

    }
    


}




