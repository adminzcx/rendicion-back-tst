using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Commands.PatchLunchForm
{
    public class PatchLunchFormCommand : IRequest, IMapFrom<Domain.Entities.LunchFormAggregate.LunchForm>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public int RestaurantId { get; set; }

        public DateTime Cai { get; set; }

        public string InvoiceType { get; set; }

        public string InvoiceNumber { get; set; }

        public int NumberOfTickets { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Iva { get; set; }

        public decimal Total { get; set; }

        public string ExceptionResponse { get; set; }

        public int BussinesDays { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PatchLunchFormCommand, Domain.Entities.LunchFormAggregate.LunchForm>()
                .ForMember(x => x.Restaurant, opt => opt.Ignore())
                .ForMember(x => x.Branch, opt => opt.Ignore())
                .ForMember(x => x.PreviousStatus, opt => opt.Ignore())
                .ForMember(x => x.Status, opt => opt.Ignore());
        }

    }
}
