
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Dtos
{
    public class LunchFormListDto : IMapFrom<Domain.Entities.LunchFormAggregate.LunchForm>
    {
        public long Id { get; set; }

        public string User { get; set; }

        public string ExpenseFormNumber { get; set; }

        public LunchFormStatusDto Status { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public DateTime Cai { get; set; }

        public DateTime ApprovalDate { get; set; }

        public string InvoiceType { get; set; }

        public string InvoiceNumber { get; set; }

        public int NumberOfTickets { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Iva { get; set; }

        public decimal Total { get; set; }

        public int BussinesDays { get; set; }

        public decimal Amount { get; set; }

        public string ExceptionResponse { get; set; }

        public decimal CostPerLunch { get; set; }

        public string Branch { get; set; }

        public string Restaurant { get; set; }

        public bool IsPaid { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.LunchFormAggregate.LunchForm, LunchFormListDto>()
           .ForMember(dest => dest.Status, m => m.MapFrom(source => source.Status))
           .ForMember(dest => dest.User, m => m.MapFrom(source => source.User.Name))
           .ForMember(dest => dest.Branch, m => m.MapFrom(source => source.Branch.Name))
           .ForMember(dest => dest.Restaurant, m => m.MapFrom(source => source.Restaurant.Name));
        }
    }
}
