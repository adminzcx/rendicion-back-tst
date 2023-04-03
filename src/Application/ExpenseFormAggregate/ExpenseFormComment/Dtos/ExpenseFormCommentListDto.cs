using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseFormComment.Dtos
{
    public class ExpenseFormCommentListDto : IMapFrom<Domain.Entities.ExpenseFormAggregate.ExpenseFormComment>
    {

        public long Id { get; set; }

        public string Description { get; set; }

        public DateTime CommentDate { get; set; }

        public string User { get; set; }



        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.ExpenseFormAggregate.ExpenseFormComment, ExpenseFormCommentListDto>()
                .ForMember(dest => dest.User, m => m.MapFrom(source => source.CommentUser.Name));
        }
    }
}
