using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchFormComment.Dtos
{
    public class LunchFormCommentListDto : IMapFrom<Domain.Entities.LunchFormAggregate.LunchFormComment>
    {

        public long Id { get; set; }

        public string Description { get; set; }

        public DateTime CommentDate { get; set; }

        public string User { get; set; }



        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.LunchFormAggregate.LunchFormComment, LunchFormCommentListDto>()
                .ForMember(dest => dest.User, m => m.MapFrom(source => source.CommentUser.Name));
        }
    }
}
