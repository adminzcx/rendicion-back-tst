
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Dtos
{
    public class RestaurantListDto : IMapFrom<Domain.Entities.LunchAggregate.Restaurant>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long Cuit { get; set; }

        public string Branch { get; set; }

        public DateTime StartDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.LunchAggregate.Restaurant, RestaurantListDto>()
             .ForMember(dest => dest.Branch, m => m.MapFrom(source => source.Branch.Name))
              ;
        }
    }
}
