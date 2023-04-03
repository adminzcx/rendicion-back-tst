using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Concept.Dtos;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Reason.Dtos;
using System;

namespace Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Dtos
{
    public class StopsDto : IMapFrom<Domain.Entities.AdminAggregate.ExpenseStops>
    {
        public long Id { get; set; }

        public ReasontDto Reason { get; set; }

        public ConceptDto Concept { get; set; }

        public DateTime ValidityStartDate { get; set; }

        public decimal CapAmount { get; set; }

        public int TypeStop { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.AdminAggregate.ExpenseStops, StopsDto>()
              .ForMember(dest => dest.Reason, m => m.MapFrom(source => source.Reason))
             .ForMember(dest => dest.Concept, m => m.MapFrom(source => source.Concept))
              ;
        }
    }
}
