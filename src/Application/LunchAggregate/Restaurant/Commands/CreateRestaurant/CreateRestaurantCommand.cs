using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Commands.CreateRestaurant
{
    public class CreateRestaurantCommand : IRequest, IMapFrom<Domain.Entities.LunchAggregate.Restaurant>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public long Cuit { get; set; }

        public int? BranchId { get; set; }

        public DateTime StartDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateRestaurantCommand, Domain.Entities.LunchAggregate.Restaurant>()
             .ForMember(x => x.Branch, opt => opt.Ignore());
        }
    }
}
