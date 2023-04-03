using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;

namespace Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Dtos
{


    public class UserSubstitutionDto : IMapFrom<UserSubstitution>
    {
        public long Id { get; set; }

        public string User { get; set; }

        public string ReplaceByUser { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserSubstitution, UserSubstitutionDto>()
             .ForMember(e => e.User, opt => opt.MapFrom(src => src.User.Name))
             .ForMember(e => e.ReplaceByUser, opt => opt.MapFrom(src => src.ReplaceByUser.Name));
        }
    }
}
