using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using System;


namespace Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Dtos
{

    public class KmPriceConfigurationListDto : IMapFrom<KmPriceConfiguration>
    {
        public long Id { get; set; }

        public decimal Price { get; set; }

        public string User { get; set; }

        public string EmployeeRecord { get; set; }

        public string Zone { get; set; }

        public string SubZone { get; set; }

        public DateTime StartDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<KmPriceConfiguration, KmPriceConfigurationListDto>()
                .ForMember(dest => dest.User, m => m.MapFrom(source => source.User.Name))
                .ForMember(dest => dest.EmployeeRecord, m => m.MapFrom(source => source.User.EmployeeRecord))
                .ForMember(dest => dest.SubZone, m => m.MapFrom(source => source.SubZone.Name))
                .ForMember(dest => dest.Zone, m => m.MapFrom(source => source.Zone.Name));
        }
    }
}
