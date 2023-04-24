using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos
{


    public class ActiveUserDto : IMapFrom<User>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, ActiveUserDto>()
             .ForMember(e => e.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
