using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;

namespace Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Dtos
{
    public class StopsListDto : IMapFrom<Domain.Entities.AdminAggregate.ExpenseStops>
    {
        public long Id { get; set; }

        public string Reason { get; set; }

        public string Concept { get; set; }

        public DateTime ValidityStartDate { get; set; }

        public decimal CapAmount { get; set; }

        public int TypeStop { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.AdminAggregate.ExpenseStops, StopsListDto>()
             .ForMember(dest => dest.Reason, m => m.MapFrom(source => source.Reason.Name))
             .ForMember(dest => dest.Concept, m => m.MapFrom(source => source.Concept.Name));
        }
    }
}
