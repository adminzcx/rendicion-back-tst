using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormComment.Dtos
{
    public class CashFormCommentListDto : IMapFrom<Domain.Entities.CashFormAggregate.CashFormComment>
    {

        public long Id { get; set; }

        public string Description { get; set; }

        public DateTime CommentDate { get; set; }

        public string User { get; set; }



        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.CashFormAggregate.CashFormComment, CashFormCommentListDto>()
                .ForMember(dest => dest.User, m => m.MapFrom(source => source.CommentUser.Name));
        }
    }
}
