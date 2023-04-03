using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Commands.CreateLunch
{
    public class CreateLunchCommand : IRequest, IMapFrom<Domain.Entities.LunchAggregate.Lunch>
    {
        public int Id { get; set; }

        public int LunchFormId { get; set; }

        public DateTime LunchDate { get; set; }

        public decimal Amount { get; set; }

        public int? UserId { get; set; }

        public string Email { get; set; }

        public string Device { get; set; }

        public bool IsInternalCollaborator { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateLunchCommand, Domain.Entities.LunchAggregate.Lunch>()
             .ForMember(x => x.IsInternalCollaborator, opt => opt.Ignore())
             .ForMember(x => x.User, opt => opt.Ignore())
             .ForMember(x => x.CreatedUser, opt => opt.Ignore());
        }
    }
}
