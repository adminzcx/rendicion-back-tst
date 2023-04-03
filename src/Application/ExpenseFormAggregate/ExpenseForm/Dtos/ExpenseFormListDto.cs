
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos
{

    public class ExpenseFormListDto : IMapFrom<Domain.Entities.ExpenseFormAggregate.ExpenseForm>
    {
        public long Id { get; set; }

        public string User { get; set; }

        public string Position { get; set; }

        public string Branch { get; set; }

        public string Management { get; set; }

        public string Sector { get; set; }

        public string ExpenseFormNumber { get; set; }

        public ExpenseFormStatusDto Status { get; set; }

        public string Description { get; set; }

        public DateTime PresentationDate { get; set; }

        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.ExpenseFormAggregate.ExpenseForm, ExpenseFormListDto>()
           .ForMember(dest => dest.Status, m => m.MapFrom(source => source.Status))
           .ForMember(dest => dest.User, m => m.MapFrom(source => source.User.Name))
           .ForMember(dest => dest.Position, m => m.MapFrom(source => source.User.Position.Name))
           .ForMember(dest => dest.Branch, m => m.MapFrom(source => source.User.Branch.Name))
           .ForMember(dest => dest.Management, m => m.MapFrom(source => source.User.Management.Name))
           .ForMember(dest => dest.Sector, m => m.MapFrom(source => source.User.Sector.Name));

        }
    }
}
