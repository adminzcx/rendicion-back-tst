using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos;
using System;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Dtos
{
    public class LunchDto : IMapFrom<Domain.Entities.LunchAggregate.Lunch>
    {
        public long Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Collaborator { get; set; }

        public string EmployeeRecord { get; set; }

        public DateTime LunchDate { get; set; }

        public string Device { get; set; }

        public decimal Amount { get; set; }

        public bool IsInternalCollaborator { get; set; }
        public IEnumerable<LunchAdviceDto> Advices { get; set; }

        public UserDto User { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.LunchAggregate.Lunch, LunchDto>()
                .ForMember(d => d.Collaborator,
                    o => o.MapFrom(s => s.User != null ? s.User.Name : s.Collaborator))
                .ForMember(d => d.User,
                    o => o.MapFrom(s => s.User))
                .ForMember(d => d.EmployeeRecord,
                    o => o.MapFrom(s => s.User != null ? s.User.EmployeeRecord : s.EmployeeRecord));
        }
    }
}
