using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchFormAudit.Dtos
{

    public class LunchFormAuditListDto : IMapFrom<Domain.Entities.LunchFormAggregate.LunchFormAudit>
    {
        public long Id { get; set; }

        public string User { get; set; }

        public string Position { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public DateTime AuditDate { get; set; }

        public decimal Amount { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.LunchFormAggregate.LunchFormAudit, LunchFormAuditListDto>()
           .ForMember(dest => dest.User, m => m.MapFrom(source => source.UserName))
           .ForMember(dest => dest.Position, m => m.MapFrom(source => source.UserPosition));

        }
    }
}
