
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos
{

    public class ExpenseListDto : IMapFrom<Domain.Entities.ExpenseAggregate.Expense>
    {
        public long Id { get; set; }

        public string Reason { get; set; }

        public string Concept { get; set; }

        public DateTime ExpenseDate { get; set; }

        public DateTime PresentationDate { get; set; }

        public decimal Amount { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal MobilityAmount { get; set; }

        public string Description { get; set; }

        public string DocumentAttached { get; set; }

        public string Device { get; set; }

        public string Source { get; set; }

        public string RequestNumber { get; set; }

        public decimal Km { get; set; }

        public string TechnicalVisit { get; set; }

        public ExpenseStatusDto Status { get; set; }

        public IEnumerable<ExpenseUserDto> Users { get; set; }

        public IEnumerable<ExpenseAdviceDto> Advices { get; set; }

        public bool RevertEnabled { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.ExpenseAggregate.Expense, ExpenseListDto>()
             .ForMember(dest => dest.Reason, m => m.MapFrom(source => source.Reason.Name))
             .ForMember(dest => dest.Status, m => m.MapFrom(source => source.Status))
             .ForMember(dest => dest.Concept, m => m.MapFrom(source => source.Concept.Name))
             .ForMember(dest => dest.Source, m => m.MapFrom(source => source.Source.Name))
             .ForMember(dest => dest.TechnicalVisit, m => m.MapFrom(source => source.TechnicalVisit.Name))
             .ForMember(dest => dest.Users, m => m.MapFrom(source => source.ExpenseUsers.ToList()))
             .ForMember(dest => dest.Advices, m => m.MapFrom(source => source.Advices.ToList()))
              ;
        }
    }
}
