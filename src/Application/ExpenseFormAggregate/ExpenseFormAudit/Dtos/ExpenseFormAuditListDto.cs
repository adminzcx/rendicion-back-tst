using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseFormAudit.Dtos
{

    public class ExpenseFormAuditListDto : IMapFrom<Domain.Entities.ExpenseFormAggregate.ExpenseFormAudit>
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
            profile.CreateMap<Domain.Entities.ExpenseFormAggregate.ExpenseFormAudit, ExpenseFormAuditListDto>()
           .ForMember(dest => dest.User, m => m.MapFrom(source => source.UserName))
           .ForMember(dest => dest.Position, m => m.MapFrom(source => source.UserPosition));

        }
    }
}
