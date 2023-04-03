using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Dtos;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Reason.Dtos;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Segment.Dtos;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Source.Dtos;
using Prome.Viaticos.Server.Application.ExpenseAggregate.TechnicalVisit.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos
{

    public class ExpenseDto : IMapFrom<Domain.Entities.ExpenseAggregate.Expense>
    {
        public long Id { get; set; }

        public ReasontDto Reason { get; set; }

        public ConceptDto Concept { get; set; }

        public DateTime ExpenseDate { get; set; }

        public DateTime PresentationDate { get; set; }

        public decimal Amount { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal MobilityAmount { get; set; }

        public string Description { get; set; }

        public string GoogleURL { get; set; }

        public string DocumentAttached { get; set; }

        public string Device { get; set; }

        public string VisitResult { get; set; }

        public string Dni { get; set; }

        public string Term { get; set; }

        public SourceDto Source { get; set; }

        public SegmentDto Segment { get; set; }

        public string RequestNumber { get; set; }

        public decimal Km { get; set; }

        public TechnicalVisitDto TechnicalVisit { get; set; }

        public ExpenseStatusDto Status { get; set; }

        public IEnumerable<ExpenseUserDto> Users { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.ExpenseAggregate.Expense, ExpenseDto>()
              .ForMember(dest => dest.Reason, m => m.MapFrom(source => source.Reason))
             .ForMember(dest => dest.Status, m => m.MapFrom(source => source.Status))
             .ForMember(dest => dest.Concept, m => m.MapFrom(source => source.Concept))
             .ForMember(dest => dest.Source, m => m.MapFrom(source => source.Source))
             .ForMember(dest => dest.Segment, m => m.MapFrom(source => source.Segment))
             .ForMember(dest => dest.TechnicalVisit, m => m.MapFrom(source => source.TechnicalVisit))
             .ForMember(dest => dest.Users, m => m.MapFrom(source => source.ExpenseUsers.ToList()))
              ;
        }
    }
}
