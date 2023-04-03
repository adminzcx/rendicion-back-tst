using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Branch.Dtos;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos
{


    public class CurrentUserDto : IMapFrom<User>
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmployeeRecord { get; set; }

        public string Email { get; set; }

        public string PositionName { get; set; }

        public BranchDto BranchFrom { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public bool? YPFRuta { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, CurrentUserDto>()
             .ForMember(e => e.PositionName, opt => opt.MapFrom(src => src.Position.Name));

        }
    }
}
